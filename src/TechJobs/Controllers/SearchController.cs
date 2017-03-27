using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Values(string column)
        {
            if (column.Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
                return View("Jobs");
            }
            else
            {
                List<string> items = JobData.FindAll(column);
                ViewBag.title = "All " + ListController.columnChoices[column] + " Values";
                ViewBag.column = column;
                ViewBag.items = items;
                return View();
            }
        }
        public IActionResult Results(string searchType, string searchTerm)

        {
            List<Dictionary<String, String>> jobs;
            if (searchType.Equals("all"))
            {
                jobs = JobData.FindByValue(searchTerm);
            }
            else
            {
                jobs = JobData.FindColumnAndValue(searchType, searchTerm);
            }
            ViewBag.title = "Jobs with " + ListController.columnChoices[searchType] + ": " + searchTerm;
            ViewBag.jobs = jobs;

            return View();
        }

    }

}

        // TODO #1 - Create a Results action method to process 
        // search request and display results

    

