{-# LANGUAGE OverloadedStrings #-}

module Main where

import Data.List
import Data.Text (replace, pack, unpack)
import System.Directory (createDirectoryIfMissing)

outputDirectory :: String
outputDirectory = "build/union"

baseName :: String
baseName = "TBase"

resultName :: String
resultName = "TResult"

indent :: Integer -> String -> String
indent n s = (concat $ replicate (fromIntegral n) "    ") ++ s

indentBlock :: Integer -> String -> String
indentBlock n s = unlines $ map (\x -> indent (fromIntegral n) x) $ lines s

-- <TBase, T1, T2, ... Tn>
genGenericParams :: Integer -> String
genGenericParams n = "<" ++ baseName ++ ", " ++ params ++ ">"
    where params = intercalate ", " $ map (\i -> "T" ++ show i) [1..n]

-- where Ti : TBase
genWhereConstraint :: Integer -> String 
genWhereConstraint i = "where T" ++ show i ++ " : " ++ baseName

-- Func<Ti, resultName> tiFn
genFuncVar :: Integer -> String
genFuncVar i = "Func<T" ++ show i ++ ", " ++ resultName ++ "> t" ++ show i ++ "Fn"

-- Action<Ti> tiAc
genActionVar :: Integer -> String
genActionVar i = "Action<T" ++ show i ++ "> t" ++ show i ++ "Ac"

-- if(this is T1 t1) { return t1Fn(t1); }
genIfFuncCall :: Integer -> String
genIfFuncCall i = "if(this is T" ++ t ++ " t" ++ t ++ ") { return t" ++ t ++ "Fn(t" ++ t ++ "); }"
    where t = show i

-- if(this is T1 t1) { t1Ac(t1); return; }
genIfActionCall :: Integer -> String
genIfActionCall i = "if(this is T" ++ t ++ " t" ++ t ++ ") { t" ++ t ++ "Ac(t" ++ t ++ "); return; }"
    where t = show i

genTplList :: (Integer -> String) -> Integer -> Integer -> String
genTplList f i n = intercalate "\n" constraints
    where constraints = map (\x -> indent (fromIntegral i) $ f x) [1..n]

genTplListComma :: (Integer -> String) -> Integer -> Integer -> String
genTplListComma f i n = intercalate ",\n" constraints
    where constraints = map (\x -> indent (fromIntegral i) $ f x) [1..n]

-- where T1 : TBase
-- where T2 : TBase
genTplWhereConstraints :: Integer -> Integer -> String
genTplWhereConstraints = genTplList genWhereConstraint

-- Func<T1, resultName> t1Fn,
-- Func<T2, resultName> t2Fn
-- ...
genTplFuncList :: Integer -> Integer -> String
genTplFuncList= genTplListComma genFuncVar

-- if(this is T2 t2) { return t2Fn(t2); }
-- if(this is T2 t2) { return t2Fn(t2); }
-- ...
genTplIfFuncCallList :: Integer -> Integer -> String
genTplIfFuncCallList = genTplList genIfFuncCall

-- Action<T1> t1Ac,
-- Action<T2> t2AC
-- ...
genTplActionList :: Integer -> Integer -> String
genTplActionList= genTplListComma genActionVar

-- if(this is T1 t1) { t1Ac(t1); return; }
-- if(this is T2 t2) { t2Ac(t2); return; }
-- ...
genTplIfActionCallList :: Integer -> Integer -> String
genTplIfActionCallList = genTplList genIfActionCall

genFullMatchFn :: Integer -> String
genFullMatchFn n = sReplace "{{ARGS}}" (genTplFuncList 1 n) 
                 $ sReplace "{{IFS}}" (genTplIfFuncCallList 1 n)
                 $ t
    where t = "public " ++ resultName ++ " Match<" ++ resultName ++ ">(\n\
        \{{ARGS}})\n\
        \{\n\
        \{{IFS}}\n\
        \\n\
        \    throw new InvalidOperationException();\n\
        \}\n"

genFullMatchAction :: Integer -> String
genFullMatchAction n = sReplace "{{ARGS}}" (genTplActionList 1 n) 
                     $ sReplace "{{IFS}}" (genTplIfActionCallList 1 n)
                     $ t
    where t = "public void Match<" ++ resultName ++ ">(\n\
        \{{ARGS}})\n\
        \{\n\
        \{{IFS}}\n\
        \\n\
        \    throw new InvalidOperationException();\n\
        \}\n"

sReplace :: String -> String -> String -> String
sReplace a b c = unpack $ replace (pack a) (pack b) (pack c)

fillTemplate :: String -> Integer -> String
fillTemplate template n = 
      sReplace "{{CLASS_GENERICS}}" (genGenericParams n) 
    $ sReplace "{{CLASS_CONSTRAINTS}}" (genTplWhereConstraints 2 n)
    $ sReplace "{{FN_FULL_MATCH}}" (indentBlock 2 $ genFullMatchFn n)
    $ sReplace "{{AC_FULL_MATCH}}" (indentBlock 2 $ genFullMatchAction n)
    $ template

genAlltemplates :: String -> Integer -> [String]
genAlltemplates template n = map (fillTemplate template) [2..n]

readTemplate :: FilePath -> IO String
readTemplate = readFile

writeFiles :: Integer -> [String] -> IO ()
writeFiles _ [] = return ()
writeFiles n (x:xs) = do 
        createDirectoryIfMissing True outputDirectory
        writeFile (outputDirectory ++ "/Union." ++ show n ++ ".cs") x
        writeFiles (n + 1) xs

main = do
        putStrLn "Generating Union.cs"
        template <- readTemplate "./union.cs.template"
        let generated = genAlltemplates template 10
        writeFiles 2 generated