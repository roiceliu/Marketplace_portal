using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketplacePortal_DAL;
using MarketplacePortal_Service;
using Marketplace_portal.Models;
using System.Web.Http;

namespace Marketplace_portal.Controllers
{
    public class FilterController : Controller
    {
        FilterViewModel viewModel = new FilterViewModel();
        FilterService fservice = new FilterService();

        List<string> types = new List<string>();


        public ActionResult Test( int[] Ids)
        {
            /*string id1 = Request.QueryString["id1"].ToString();
            string id2 = Request.QueryString["id2"].ToString();
            string id3 = Request.QueryString["id3"].ToString();
            ViewData["id1"] = id1;
            ViewData["id2"] = id2;
            ViewData["id3"] = id3;*/
            

            List<String> ids = new List<string>();
            if (Ids[0]==-1) { 
            
            }
            else
            {
                foreach(int num in Ids)
                {
                    ids.Add(num.ToString());
                }
            }
            
            return View(ids);
        }

        public ActionResult TestProductDetail(int id)
        {
            int id1 = id;
            ViewData["id"] = id;

            return View();
        }
            // GET: Filter
            public ActionResult Fans(string state, string dropdown, int? yearmin, int? yearmax, int? airmin, int? airmax, int? powermin, int? powermax, int? soundmax, int? soundmin, int? fanmax, int? fanmin)
        {

            //var searchCriteria = Session["searchCriteria"] as String;

            //var saveSate = ViewData["saved"] as String;

           
            
            viewModel.subcategory = "Fans";
            Session["subcategory"] = "Fans";
            //get different types for subclass
            types = fservice.GetTypesBySubcategory(viewModel.subcategory);

            foreach (string type in types) 
            {
                viewModel.productTypes.Add(type);

            }

            //Manage save states
            if (state == null)
            {
                ViewData["saved"] = "Original";
                ViewData["dropDown"] = "       ";
                ViewData["yearMin"] = "";
                ViewData["yearMax"] = "";
                ViewData["airmin"] = 10;
                ViewData["airmax"] = 90;
                ViewData["powermin"] = 10;
                ViewData["powermax"] = 90;
                ViewData["soundmin"] = 10;
                ViewData["soundmax"] = 90;
                ViewData["fanmin"] = 10;
                ViewData["fanmax"] = 90;
            }
            if (state == "true")
            {

                ViewData["saved"] = "Saved On";
                ViewData["dropDown"] = dropdown;
                viewModel.productTypes.Remove(dropdown);
                ViewData["yearMin"] = yearmin;
                ViewData["yearMax"] = yearmax;
                ViewData["airmin"] = airmin;
                ViewData["airmax"] = airmax;
                ViewData["powermin"] = powermin;
                ViewData["powermax"] = powermax;
                ViewData["soundmin"] = soundmin;
                ViewData["soundmax"] = soundmax;
                ViewData["fanmin"] = fanmin;
                ViewData["fanmax"] = fanmax;

            }

            if (state == "false")
            {

                ViewData["saved"] = "Saved On";
                ViewData["dropDown"] = dropdown;
                viewModel.productTypes.Remove(dropdown);
                ViewData["yearMin"] = yearmin;
                ViewData["yearMax"] = yearmax;
                ViewData["airmin"] = airmin;
                ViewData["airmax"] = airmax;
                ViewData["powermin"] = powermin;
                ViewData["powermax"] = powermax;
                ViewData["soundmin"] = soundmin;
                ViewData["soundmax"] = soundmax;
                ViewData["fanmin"] = fanmin;
                ViewData["fanmax"] = fanmax;

            }

            //add temp values for product type dropdownlist

            /*viewModel.productTypes.Add("Roof");
            viewModel.productTypes.Add("Commercial");
            viewModel.productTypes.Add("Non Commercial");
            viewModel.productTypes.Add("With Light");*/

            ViewData["select"] = "     ";

            return View(viewModel);
        }

            public ActionResult _Products() {

            if (viewModel.products.Count > 0)
            {
                viewModel.products.Clear();
            }

            //string save = Request.QueryString["save"].ToString();

            string type = Request.QueryString["type"].ToString();
            float airFlowMax = float.Parse(Request.QueryString["airFlowMax"].ToString());
            float airFlowMin = float.Parse(Request.QueryString["airFlowMin"].ToString());

            float maxPowerMax = float.Parse(Request.QueryString["maxPowerMax"].ToString());
            float maxPowerMin = float.Parse(Request.QueryString["maxPowerMin"].ToString());

            float soundSpeedMax = float.Parse(Request.QueryString["soundSpeedMax"].ToString());
            float soundSpeedMin = float.Parse(Request.QueryString["soundSpeedMin"].ToString());

            float fanSweepMax = float.Parse(Request.QueryString["fanSweepMax"].ToString());
            float fanSweepMin = float.Parse(Request.QueryString["fanSweepMin"].ToString());

            int yearMax;
            if (!int.TryParse(Request.QueryString["yearMax"].ToString(), out yearMax)) {
                yearMax = Int32.MaxValue;
            }
            int yearMin;
            if (!int.TryParse(Request.QueryString["yearMin"].ToString(), out yearMin))
            {
                yearMin = Int32.MinValue;
            }



            //get unfiltered products

            //get products by type
            List <tblProduct> productsByType = fservice.GetProductsByProductType(type);

            //get products by property name
            List<tblProduct> productsByPropertyName = fservice.GetProductsByPropertyName("Air Flow");
            List<tblProduct> productsByPropertyName2 = fservice.GetProductsByPropertyName("Power");
            List<tblProduct> productsByPropertyName3 = fservice.GetProductsByPropertyName("Sound at Max Speed");
            List<tblProduct> productsByPropertyName4 = fservice.GetProductsByPropertyName("Fan Sweep Diameter");

            //get products by model year
            List<tblProduct> productsByBetweenModelYear = new List<tblProduct>();
            if ( yearMin< yearMax)
            {
                productsByBetweenModelYear = fservice.GetProductsBetweenModelYear( yearMin, yearMax);
            }
            else if (yearMin > yearMax)
            {
                productsByBetweenModelYear = fservice.GetProductsBetweenModelYear(yearMax, yearMin);
            }
            else
            {
                productsByBetweenModelYear = fservice.GetProductsBetweenModelYear(yearMax, yearMin);
            }


            //filter code


            viewModel.propertyValues = fservice.GetAlltblPropertyValues().ToList();



            //filter by min max Airflow
            List<tblProduct> productsByAirFlowMinMax = new List<tblProduct>();
            int idAirFlowProp = fservice.GetPropertyIDByName("Air Flow");
            

            for (int i = 0; i < productsByPropertyName.Count; i++)
            {
                for (int j = 0; j < viewModel.propertyValues.Count; j++)
                {
                    float airFlowValue;
                    

                    bool success = float.TryParse(viewModel.propertyValues[j].Value, out airFlowValue);
                    

                    if ((productsByPropertyName[i].ProductID == viewModel.propertyValues[j].ProductID) & (airFlowValue >= airFlowMin) & (airFlowValue <= airFlowMax) & (viewModel.propertyValues[j].PropertyID==idAirFlowProp))
                     {
                        productsByAirFlowMinMax.Add(productsByPropertyName[i]);
                        continue;

                     }

                }
 
            }

            //filter max Power
            List<tblProduct> productsByPowerMinMax = new List<tblProduct>();
            int idMaxPowerProp = fservice.GetPropertyIDByName("Power");

            for (int i = 0; i < productsByPropertyName2.Count; i++)
            {
                for (int j = 0; j < viewModel.propertyValues.Count; j++)
                {
                    //float maxPowerValue = (float)viewModel.propertyValues[j].Max;

                    if ((productsByPropertyName2[i].ProductID == viewModel.propertyValues[j].ProductID) & (viewModel.propertyValues[j].Max >= maxPowerMin) & (viewModel.propertyValues[j].Max <= maxPowerMax) & (viewModel.propertyValues[j].PropertyID == idMaxPowerProp))
                    {
                        productsByPowerMinMax.Add(productsByPropertyName2[i]);
                        continue;

                    }

                }

            }

            //filter by sound at max speed
            List<tblProduct> productsSoundMinMax = new List<tblProduct>();
            int idSoundProp = fservice.GetPropertyIDByName("Sound at Max Speed");


            for (int i = 0; i < productsByPropertyName3.Count; i++)
            {
                for (int j = 0; j < viewModel.propertyValues.Count; j++)
                {
                    float soundValue;


                    bool success = float.TryParse(viewModel.propertyValues[j].Value, out soundValue);


                    if ((productsByPropertyName3[i].ProductID == viewModel.propertyValues[j].ProductID) & (soundValue >= soundSpeedMin) & (soundValue <= soundSpeedMax) & (viewModel.propertyValues[j].PropertyID == idSoundProp))
                    {
                        productsSoundMinMax.Add(productsByPropertyName3[i]);
                        continue;

                    }

                }

            }


            //filter by fan sweep diameter
            List<tblProduct> productsByFanSweepMinMax = new List<tblProduct>();
            int idFanSweepProp = fservice.GetPropertyIDByName("Fan Sweep Diameter");


            for (int i = 0; i < productsByPropertyName4.Count; i++)
            {
                for (int j = 0; j < viewModel.propertyValues.Count; j++)
                {
                    float fanSweepValue;


                    bool success = float.TryParse(viewModel.propertyValues[j].Value, out fanSweepValue);


                    if ((productsByPropertyName4[i].ProductID == viewModel.propertyValues[j].ProductID) & (fanSweepValue >= fanSweepMin) & (fanSweepValue <= fanSweepMax) & (viewModel.propertyValues[j].PropertyID == idFanSweepProp))
                    {
                        productsByFanSweepMinMax.Add(productsByPropertyName4[i]);
                        continue;

                    }

                }

            }




            var ids = productsByType.Select(x => x.ProductID).Intersect(productsByAirFlowMinMax.Select(x => x.ProductID));
            var filteredProducts = productsByType.Where(x => ids.Contains(x.ProductID));

            var ids2 = filteredProducts.Select(x => x.ProductID).Intersect(productsByPowerMinMax.Select(x => x.ProductID));
            var filteredProducts2 = filteredProducts.Where(x => ids2.Contains(x.ProductID));

            var ids3 = filteredProducts2.Select(x => x.ProductID).Intersect(productsSoundMinMax.Select(x => x.ProductID));
            var filteredProducts3 = filteredProducts2.Where(x => ids3.Contains(x.ProductID));

            var ids4 = filteredProducts3.Select(x => x.ProductID).Intersect(productsByFanSweepMinMax.Select(x => x.ProductID));
            var filteredProducts4 = filteredProducts3.Where(x => ids4.Contains(x.ProductID));

            var ids5 = filteredProducts4.Select(x => x.ProductID).Intersect(productsByBetweenModelYear.Select(x => x.ProductID));
            var filteredProducts5 = filteredProducts4.Where(x => ids5.Contains(x.ProductID));


            //assign products to show
            viewModel.products = filteredProducts5.ToList<tblProduct>();





            viewModel.property = fservice.GetAllProperty().ToList();

            //get details of products



            if (viewModel.products != null)
            {
                if (Convert.ToString(@Session["subcategory"]) == "Fans")
                {
                    var airflowKey = -1;
                    var maxPowerKey = -1;
                    var soundMaxKey = -1;
                    var fanSweepDiameterKey = -1;


                    for (int i = 0; i < viewModel.property.Count; i++)
                    {
                        if (Convert.ToString(viewModel.property[i].PropertyName) == "Air Flow")
                        {
                            airflowKey = viewModel.property[i].PropertyID;
                        }

                        if (Convert.ToString(viewModel.property[i].PropertyName) == "Power")
                        {
                            maxPowerKey = viewModel.property[i].PropertyID;
                        }

                        if (Convert.ToString(viewModel.property[i].PropertyName) == "Sound at Max Speed")
                        {
                            soundMaxKey = viewModel.property[i].PropertyID;
                        }

                        if (Convert.ToString(viewModel.property[i].PropertyName) == "Fan Sweep Diameter")
                        {
                            fanSweepDiameterKey = viewModel.property[i].PropertyID;
                        }
                    }

                    String div = "";
                    IHtmlString str = new HtmlString(div);
                    int checkBoxID = 1;
                    foreach (var Data in viewModel.products)
                    {
                        String airflowValue = "";
                        float maxPowerValue = -1.1f;
                        String soundMaxValue = "";
                        String fanSweepDiameterValue = "";
                        

                        for (int i = 0; i < viewModel.propertyValues.Count; i++)
                        {

                            if ((Data.ProductID == viewModel.propertyValues[i].ProductID) & (viewModel.propertyValues[i].PropertyID == airflowKey))
                            {

                                airflowValue = viewModel.propertyValues[i].Value;
                            }
                            if ((Data.ProductID == viewModel.propertyValues[i].ProductID) & (viewModel.propertyValues[i].PropertyID == maxPowerKey))
                            {

                                maxPowerValue = (float)viewModel.propertyValues[i].Max;
                            }
                            if ((Data.ProductID == viewModel.propertyValues[i].ProductID) & (viewModel.propertyValues[i].PropertyID == soundMaxKey))
                            {

                                soundMaxValue = viewModel.propertyValues[i].Value;
                            }

                            if ((Data.ProductID == viewModel.propertyValues[i].ProductID) & (viewModel.propertyValues[i].PropertyID == fanSweepDiameterKey))
                            {

                                fanSweepDiameterValue = viewModel.propertyValues[i].Value;
                            }
                        }

                        div = "<a href=\"/Filter/TestProductDetail/" + Data.ProductID.ToString() + "\" id=\"ProductDiv\" > "
                              + "<div class = \"productDiv\">"
                              + "<div> <img class = \"productImg\" runat=\"server\" src=\"../../" + Data.ProductImage + "\"alt=\"Fan Image\" > </div>"
                              + "<div><b>" + Data.ProductName + "</b></div>"
                              + "<div><b>" + Data.Series + "</b></div>"
                              + "<div><b>" + Data.Model + "</b></div>"
                              + "&nbsp"
                              + "&nbsp"
                              + "<div>" + airflowValue + " CFM </div>"
                              + "&nbsp"
                              + "<div>" + maxPowerValue + " W at max speed</div>"
                              + "&nbsp"
                              + "<div>" + soundMaxValue + " dBA at max speed</div>"
                              + "&nbsp"
                              + "<div>" + fanSweepDiameterValue + " fan sweep diamter</div>"
                              + "&nbsp"
                              + "</a>"
                              + "<div>"
                                + "<input type=\"checkbox\" id=\"checkbox"+ checkBoxID+ "\" name=\"checkbox"+ checkBoxID+"\" value=\"" +Data.ProductID +"\">"
                                + "<label for=\"checkbox" +checkBoxID+"\"> Compare </label>"
                                + "&nbsp"
                                + "<input id = \"CompareButton\" class=\"divButton\" type = \"submit\" value = \"Add\" >"
                              + "</div>"
                              + "</div>"                         
                              
                              + "&nbsp"
                              + "&nbsp"
                              + "&nbsp"
                              + "&nbsp";
                        str = new HtmlString(div);


                        viewModel.listOfDivs.Add(str);
                        checkBoxID++;
                        if (checkBoxID > 3) {
                            break;
                        }
                    }

                }
            }


                    return PartialView(viewModel);
        
        }

       
    }
}