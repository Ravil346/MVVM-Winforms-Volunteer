using BuisnessLogic.Models.Request;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UserPanels
{
    public class IncidentsPanel
    {
        public Panel WorkPanel { get; set; }    
       
        public Panel InnerPanel { get;set; }
        private IUserRepositry<UserInfoRequest> UserRepositry { get; set; }
        private IEventsRepository<IncidentInfoRequest> EventsRepository { get; set; }

        private string _Email;
        public IncidentsPanel(string email, Panel basepanel)
        {
            WorkPanel = basepanel;  
            _Email = email;
            InnerPanel = new Panel()
            {
                Size = new Size(WorkPanel.Size.Width - 30, WorkPanel.Size.Height),
                AutoScroll = true,
                MaximumSize = WorkPanel.Size,
            };

            var unitOfWork = UnitOfWorkInit.GetUnitOfWork();
            EventsRepository = unitOfWork.Incidents;
            UserRepositry = unitOfWork.Users;
            IList<Incident> allEvents = unitOfWork.Incidents.GetIncidents(x => x.Exists is null).ToList();
           
            var first = InnerPanel.Location.Y;
            foreach(var inc in allEvents)
            {
                InnerPanel.Controls.Add(IncidentToPanel(inc, first));
                first += 100;
            }
            
            WorkPanel.Controls.Add(InnerPanel);

        }
        private Panel IncidentToPanel(Incident incident, int yBaseLocation)
        {
            var panel = new Panel()
            {
                AutoSize = true,
                
                BackColor = FormConstStorage.BackColorForIncident,
            };
            using (var httpClient = new HttpClient())
            {
                PictureBox? pb = null;
                if (incident.BinaryData is not null)
                {
                    var task = httpClient.GetStreamAsync(incident.BinaryData!.LinkOnData);

                    task.Wait();

                    var response = task.Result;

                    pb = new PictureBox()
                    {
                        Image = Image.FromStream(response),

                        SizeMode = PictureBoxSizeMode.CenterImage,

                        Size = new Size(64, 64),

                        //Location = new Point(panel.Location.X, panel.Location.Y + panel.Size.Height),

                        BackColor = Color.DarkSlateGray,
                    };

                    panel.Controls.Add(pb);
                }

                var label = new Label()
                {
                    Text = incident.Name,

                    Location = new Point(panel.Location.X, pb is not null ? pb.Size.Height + pb.Location.Y : 0 ),

                    AutoSize = true,

                    Font = FormConstStorage.BaseFont,

                };
                panel.Controls.Add(label);

                var user = UserRepositry.Get(_Email);

                if (user is null) throw new NullReferenceException();

                var userincidents = EventsRepository.GetUserIncidents(user!.Id);

                var condition = userincidents!.Where(x => x.Name == label.Text).FirstOrDefault() is not null;

                var button = new Button()
                {
                    Text =  condition ? "Вы записаны" : $"Записаться на {label.Text}",

                    Location = new Point(panel.Location.X, label.Size.Height + label.Location.Y + 30),

                    ForeColor = FormConstStorage.BaseForeColorForButton,

                    BackColor = FormConstStorage.BaseBackColorForButton,

                    Size = new Size(200,40),

                    Enabled = !condition,
                };
                button.Click += Button_Click;
                panel.Controls.Add(button);
                panel.Location = new Point(panel.Location.X, yBaseLocation);
                return panel;
            }
            
            
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            var button = sender as Button;
            var eventName = button!.Text.Substring(button.Text.LastIndexOf("на ") + 3);
            var user = UserRepositry.Get(_Email);

            if (user is null) return;
           
            EventsRepository.AddLinkOnUser(new IncidentInfoRequest()
            {
                User = user,
                Name = eventName,
            });
        }
    }
}
