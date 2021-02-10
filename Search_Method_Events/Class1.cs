using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_Method_Events
{
    public class Class1
    {
        SearchDataBaseEntities sdbe = new SearchDataBaseEntities();
        searchData newSearch;
        resultData newResult;

        public delegate void SearchHandler(string result);
        public event SearchHandler FilesFound;

        public delegate void AlertNullorEmpty();
        public event AlertNullorEmpty AlertMsg;

        public delegate void IfNotFileFound();
        public event IfNotFileFound FileNotFound;

        public string[] _searchFile;


        public void SaveSearchData(string inputPath, string inputFile)
        {
            string checkDir = inputPath;
            string checkFile = inputFile;

            try
            {
                if (String.IsNullOrEmpty(checkFile) == false)
                {
                    if (String.IsNullOrEmpty(checkDir) == false)
                    {
                        newSearch = new searchData
                        {
                            path = inputPath,
                            filename = inputFile
                        };

                        sdbe.searchDatas.Add(newSearch);
                        sdbe.SaveChanges();
                        RecursiveSearchAndSaveResult(inputPath, "*" + inputFile + "*.*");
                    }
                }
                else
                {
                    AlertMsg();
                }
            }
            catch (Exception inputError)
            {

                throw inputError;
            }
        }

        public void RecursiveSearchAndSaveResult(string direction, string fileName)
        {

            _searchFile = Directory.GetFiles(direction, "*" + fileName.ToLower() + "*.*");
            foreach (string file in _searchFile)
            {

                FilesFound(file);
            }

            string[] searchDir = Directory.GetDirectories(direction);
            foreach (string dir in searchDir)
            {
                RecursiveSearchAndSaveResult(dir, fileName);
            }

            foreach (string fileFound in _searchFile)
            {
                SaveResultData(fileFound);
            }
            sdbe.SaveChanges();


        }

        public void SaveResultData(string fullPath)
        {
            if (_searchFile.Length > 0)
            {
                newResult = new resultData
                {
                    resultpath = fullPath
                };

                sdbe.resultDatas.Add(newResult);
            }

            else
            {
                FileNotFound();
            }
        }
    }
}
