using Microsoft.AspNetCore.Mvc.Rendering;
using OPUS_Demo_5.Models;
using OPUS_Demo_5.Models.DataContexts;
using OPUS_Demo_5.Models.QuoteMatrix;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OPUS_Demo_5.ViewModels
{
    public class BifoldItemViewModel
    {
        public Quote ParentQuote { get; set; }

        public PricingFactor PricingFactors { get; set; }

        public BifoldItem thisBifoldItem { get; set; }

        public List<PeripheralItem> thisPeripheralItems { get; set; }

        public string SelectedBifoldStyleCode { get; set; }

        public List<ProfileColour> ProfileColourOptions { get; set; }


        public List<HardwareColour> HardwareColourOptions { get; set; }


        public string InternalColourName { get; set; }

        public string ExternalColourName { get; set; }

        public decimal ItemQuoteValue { get; set; }

        public string SelectedOpeningOption { get; set; }



        [Display(Name ="Opening Option")]
        public List<SelectListItem> OpeningOptions = new List<SelectListItem>()
        {
            new SelectListItem{Value = "Open Out", Text = "Open Out"},
            new SelectListItem{Value = "Open In", Text = "Open In"}
        };


        public string SelectedSashProfile { get; set; }

        [Display(Name = "Sash Profile")]
        public List<SelectListItem> SashProfileOptions = new List<SelectListItem>()
        {
            new SelectListItem{Value = "Standard", Text = "Standard"},
            new SelectListItem{Value = "Flat", Text = "Flat"}
        };

        public int SelectedDoorQuantity { get; set; }


        [Display(Name ="Door Quantity")]
        public List<SelectListItem> DoorQuantityOptions = new List<SelectListItem>()
        {
            new SelectListItem{Value = "1", Text = "1"},
            new SelectListItem{Value = "2", Text = "2"},
            new SelectListItem{Value = "3", Text = "3"},
            new SelectListItem{Value = "4", Text = "4"},
            new SelectListItem{Value = "5", Text = "5"},
            new SelectListItem{Value = "6", Text = "6"}
        };



    }
}
