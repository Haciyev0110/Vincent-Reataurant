using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace VincentRestorant.Extino
{
    public class Extension
    {

        public static readonly double MAxfileSize = 1;

        public static bool CheckImg(HttpPostedFileBase _img, double _fileSizeMb)
        {

            return Convert.ToDouble(_img.ContentLength / 1024 / 1024) <= _fileSizeMb
                &&
                (_img.ContentType == "image/jpg" ||
                _img.ContentType == "image/png" ||
                _img.ContentType == "image/jpeg" ||
                _img.ContentType == "image/gif");


        }


        public static string SaveImg(HttpPostedFileBase _img, string path)
        {
            if (_img != null)   
            {
                string filesub = DateTime.Now.ToString("yyyy_MM_DD_hh_mm_ss");
                string filename = filesub + _img.FileName;

                string imagePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(path), filename);
                _img.SaveAs(imagePath);
                return filename;
            }
            else
            {
                return "sdasds";
            }
        }
        public static void Deletimg(string _path, string _filename)
        {
            string imagePath = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(_path), _filename);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }
    }
}