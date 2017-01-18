﻿using Xunit;
using HoneymoonShop.Controllers;
using HoneymoonShop.Data;
using HoneymoonShop.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit.Sdk;
using System.Collections.Generic;
using System.Linq;

namespace HoneymoonShop.UnitTests
{
    public class Class1
    {
        [Fact]
        public void TestDelete()
        {
            Jurk jurk = new Jurk() {Artikelnummer = 9999999, JurkId = 1};
            Jurk jurk2 = new Jurk() {Artikelnummer = 11111111, JurkId = 2};
            HoneyMoonShopContext context = new HoneyMoonShopContext();
            context.Add(jurk);
            context.Add(jurk2);
            var mock = new Mock<IHoneymoonshopRepository>();

            mock.Setup(x => x.DeleteJurk(jurk.JurkId));
            
            BeheerController beheer = new BeheerController(mock.Object);
            beheer.Delete(jurk.JurkId);
            mock.Verify(f => f.DeleteJurk(jurk.JurkId));

        }
        //werkt
        [Fact]
        public void Geldige_Edit_BeheerController()
        {
            var mock = new Mock<IHoneymoonshopRepository>();
            BeheerController controller = new BeheerController(mock.Object);
            Jurk jurk = new Jurk() { Artikelnummer = 9999999, JurkId = 1 };
            var result = controller.Edit(jurk);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Crud", redirectToActionResult.ActionName);
        }
      
        [Fact]
        public void FilterVerwerkenReturnsJuisteJurk()
        {
            string[] filterMerk = { "Maggie Sottero" };
            string[] filterStijl = {}; // { "Kant" };
            string neklijnDd = null;// "strapless";
            string silhouetteDd = null; //"Fishtail";
            string[] slider = {}; //{ "1200", "2300" };
            string kleurenDd = null;
            /*
            Jurk jurk1 = new Jurk() { JurkId = 34, Artikelnummer = 34, Merk = "Maggie Sottero", Stijl = "Kant", MinPrijs = 1200, MaxPrijs = 2300, Neklijn = "strapless", Silhouette = "Fishtail" };
            Jurk jurk2 = new Jurk() { JurkId = 35, Artikelnummer = 012, Merk = "Ladybird", Stijl = "Kant", MinPrijs = 1200, MaxPrijs = 2300, Neklijn = "strapless", Silhouette = "Fishtail" };
            Jurk jurk3 = new Jurk() { JurkId = 36, Artikelnummer = 012, Merk = "Ladybird", Stijl = "Verleidelijk", MinPrijs = 1200, MaxPrijs = 2300, Neklijn = "strapless", Silhouette = "Fishtail" };
            // Arrange
            // - create the mock repository
            Mock<IHoneymoonshopRepository> mock = new Mock<IHoneymoonshopRepository>();
            mock.Setup(m => m.Jurken).Returns(new List<Jurk>()  {
              jurk1, jurk2, jurk3
            }.AsQueryable());
            */
            // Arrange - create a controller
            DressFinderController dtf = new DressFinderController();

            // Action
            PartialViewResult result = (PartialViewResult)dtf.FilterVerwerken(filterMerk, filterStijl, neklijnDd, silhouetteDd, kleurenDd, slider, null);

            // Assert
            Assert.Equal(((IEnumerable<Jurk>)result.ViewData.Model).Count(), 1);
            Assert.True(((IEnumerable<Jurk>)result.ViewData.Model).Count(j => j.Merk == "Maggie Sottero") == 1);
        }
    }
}   