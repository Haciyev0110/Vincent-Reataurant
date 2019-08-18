using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;


namespace VincentRestorant.ViewModel
{
    public class AAbout
    {

        public List<Second_Slider> secon_slider { get; set; }
        public List<Adres_First> adress { get; set; }
        public List<Partner> partners { get; set; }
        public List<Team> teams { get; set; }
        public List<Information> information { get; set; }
        public List<Category> categories { get; set; }
        
    }
}