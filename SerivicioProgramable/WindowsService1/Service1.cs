using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Timers;
using System.Runtime.Remoting.Messaging;

namespace Servicio1
{
    public partial class Service1 : ServiceBase
    {
        public System.Timers.Timer TimerServicio = new System.Timers.Timer();

        protected override void OnStart(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\DiaHoraInter.txt");
            string dia = lines[0];
            string hora = lines[1];
            string intervalo = lines[2];
            DayOfWeek wk = DateTime.Today.DayOfWeek;
            String horaAct = DateTime.Now.ToString("HH:mm");

            TimerServicio = new System.Timers.Timer();
            TimerServicio.Elapsed += (_, __) => EjecutaUnaAccion();

            if (dia=="Lunes")
            {
                if (wk == DayOfWeek.Monday)
                    do
                    {
                        horaAct = DateTime.Now.ToString("HH:mm");
                        TimerServicio.Interval = Convert.ToDouble(intervalo);
                    } while (horaAct != hora);
                TimerServicio.Start();
            }
            else if (dia == "Martes")
            {
                if (wk == DayOfWeek.Tuesday)
                    do
                    {
                        horaAct = DateTime.Now.ToString("HH:mm");
                        TimerServicio.Interval = Convert.ToDouble(intervalo);
                    } while (horaAct != hora);
                TimerServicio.Start();
            }
            else if (dia == "Miercoles")
            {
                if (wk == DayOfWeek.Wednesday)
                    do
                    {
                        horaAct = DateTime.Now.ToString("HH:mm");
                        TimerServicio.Interval = Convert.ToDouble(intervalo);
                    } while (horaAct != hora);
                TimerServicio.Start();
            }
            else if (dia == "Jueves")
            {
                if (wk == DayOfWeek.Thursday)
                    do
                    {
                        horaAct = DateTime.Now.ToString("HH:mm");
                        TimerServicio.Interval = Convert.ToDouble(intervalo);
                    } while (horaAct != hora);
                TimerServicio.Start();
            }
            else if (dia == "Viernes")
            {
                if (wk == DayOfWeek.Friday)
                    do
                    {
                        horaAct = DateTime.Now.ToString("HH:mm");
                        TimerServicio.Interval = Convert.ToDouble(intervalo);
                    } while (horaAct != hora);
                TimerServicio.Start();
            }
            else if (dia == "Sabado")
            {
                if (wk == DayOfWeek.Saturday)
                    do
                    {
                        horaAct = DateTime.Now.ToString("HH:mm");
                        TimerServicio.Interval = Convert.ToDouble(intervalo);
                    } while (horaAct != hora);
                TimerServicio.Start();
            }
            else if (dia == "Domingo")
            {
                if (wk == DayOfWeek.Sunday)
                    do
                    {
                        horaAct = DateTime.Now.ToString("HH:mm");
                        TimerServicio.Interval = Convert.ToDouble(intervalo);
                    } while (horaAct != hora);
                TimerServicio.Start();
            }
        }

        public void EjecutaUnaAccion()
        {
            int i;
            for (i = 1; i <= 10; i++)
            { 
                File.AppendAllText(@"D:\INFORME.TXT", "LINEA: " + i + System.Environment.NewLine);
                File.Create(@"D:\CarpetaLog\Log.TXT");
               
            }
            TimerServicio.Close();
    
        }
        protected override void OnStop()
        {
            TimerServicio.Close();
        }
        protected override void OnPause()
        {
            TimerServicio.Stop();
        }

        protected override void OnContinue()
        {
            TimerServicio.Start();
        }
        public static void GrabarLog(string sistema, string titulo, string texto) {
            string dir= @"D:\CarpetaLog";
            File.Create(@"D:\CarpetaLog\Log.TXT");
            int i=1;
            
            if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

            try
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[]
                {
                    new Servicio_Focus()
                };
            ServiceBase.Run(ServicesToRun);
                   GrabarLog("Log", "Inicio del Servicio,", "Servicio Iniciado");
                
            }
                catch (Exception e)
{
            GrabarLog("Log", "Service_Error al crear servicio", e.Message);
                File.AppendAllText(@"D:\CarpetaLog\Log.TXT", "Error: " + i + System.Environment.NewLine);
                i += 1;
            }
    }
}

    internal class Servicio_Focus : ServiceBase
    {
    }
}

