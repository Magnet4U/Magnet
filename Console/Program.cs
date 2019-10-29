using Data;
using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDBContext ctx = new MyDBContext();


            //Ajouter un interview à partir de la classe InterviewService 
            IInterviewService intService = new InterviewService();
            Interview interview = new Interview() { idInterview = 1 , lieu="Tunisie" };
            intService.Add(interview);
            intService.Commit();
            intService.dispose();
            


        }
    }
}
