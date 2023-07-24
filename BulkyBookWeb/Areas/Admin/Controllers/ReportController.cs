using BulkyBook.DataAccess.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReportController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DemoReport1Download()
        {
            IEnumerable<Employee> objEmployeeList = _unitOfWork.Employee.GetAll();
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rptControlsDemo.rdlc";
            LocalReport report = new LocalReport();
            report.ReportPath = path;
            IEnumerable<ReportParameter> parameters = new[] { new ReportParameter("reportHeading", "Employee List") };
            ReportDataSource dataSource = new ReportDataSource("rptControlsDemoDto", objEmployeeList);
            report.SetParameters(parameters);
            report.DataSources.Add(dataSource);
            byte[] pdfData = report.Render("PDF");
            return File(pdfData, "application/pdf", "report.pdf");
        }

        public IActionResult DemoReport2Download()
        {
            IEnumerable<FeeCollection> objFeeCollectionList = _unitOfWork.FeeCollection.GetAll();
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rptMatrixReport.rdlc";
            LocalReport report = new LocalReport();
            report.ReportPath = path;
            IEnumerable<ReportParameter> parameters = new[] { new ReportParameter("reportHeading", "Fee Collection List") };
            ReportDataSource dataSource = new ReportDataSource("rptMatrixReportDto", objFeeCollectionList);
            report.SetParameters(parameters);
            report.DataSources.Add(dataSource);
            byte[] pdfData = report.Render("PDF");
            return File(pdfData, "application/pdf", "report.pdf");
        }

        public IActionResult DemoReport3Download()
        {
            IEnumerable<Employee> objEmployeeList = _unitOfWork.Employee.GetAll();
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rptChartReport.rdlc";
            LocalReport report = new LocalReport();
            report.ReportPath = path;
            IEnumerable<ReportParameter> parameters = new[] { new ReportParameter("reportHeading", "City Wise Employee Chart") };
            ReportDataSource dataSource = new ReportDataSource("rptControlDemoDto", objEmployeeList);
            report.SetParameters(parameters);
            report.DataSources.Add(dataSource);
            byte[] pdfData = report.Render("PDF");
            return File(pdfData, "application/pdf", "report.pdf");
        }       

        public IActionResult DemoReport4Download()
        {
            IEnumerable<Employee> objEmployeeList = _unitOfWork.Employee.GetAll();
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rptEmployeeReport.rdlc";
            LocalReport report = new LocalReport();
            report.ReportPath = path;
            IEnumerable<ReportParameter> parameters = new[] { new ReportParameter("reportHeading", "Employee List") };
            ReportDataSource dataSource = new ReportDataSource("rptEmployeeDto", objEmployeeList);
            report.SetParameters(parameters);
            report.DataSources.Add(dataSource);

            #region Sub Report
            report.SubreportProcessing += new SubreportProcessingEventHandler(SubReportProccessing);
            #endregion

            byte[] pdfData = report.Render("PDF");
            return File(pdfData, "application/pdf", "report.pdf");
        }

        public IActionResult DemoReport5Download()
        {
            IEnumerable<Employee> objEmployeeList = _unitOfWork.Employee.GetAll();
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rptListControl.rdlc";
            LocalReport report = new LocalReport();
            report.ReportPath = path;
            IEnumerable<ReportParameter> parameters = new[] { new ReportParameter("reportHeading", "List Control Demo") };
            ReportDataSource dataSource = new ReportDataSource("rptControlsDemoDto", objEmployeeList);
            report.SetParameters(parameters);
            report.DataSources.Add(dataSource);
            byte[] pdfData = report.Render("PDF");
            return File(pdfData, "application/pdf", "report.pdf");
        }

        public IActionResult DemoReport6Download()
        {
            IEnumerable<FeeCollection> objFeeCollectionList = _unitOfWork.FeeCollection.GetAll();
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rptGauge.rdlc";
            LocalReport report = new LocalReport();
            report.ReportPath = path;
            IEnumerable<ReportParameter> parameters = new[] { new ReportParameter("reportHeading", "Gauge Demo") };
            ReportDataSource dataSource = new ReportDataSource("rptMatrixReportDto", objFeeCollectionList);
            report.SetParameters(parameters);
            report.DataSources.Add(dataSource);
            byte[] pdfData = report.Render("PDF");
            return File(pdfData, "application/pdf", "report.pdf");
        }

        void SubReportProccessing(object sender,SubreportProcessingEventArgs e)
        {
            int EmpId = Convert.ToInt32(e.Parameters["EmpId"].Values[0]);
            IEnumerable<Employee> objEmployeeDetails = _unitOfWork.Employee.GetAll().Where(x=>x.Id == EmpId);
            ReportDataSource dataSource = new ReportDataSource("rptEmployeeDetailsDto", objEmployeeDetails);
            e.DataSources.Add(dataSource);
        }
    }
}