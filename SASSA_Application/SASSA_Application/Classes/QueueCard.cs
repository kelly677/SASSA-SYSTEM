using System;
using System.Drawing;
using System.Windows.Forms;

namespace SASSA_Application.Classes
{
    public class QueueCard : CurvedCornerPanel
    {
        public string BookingRef { get; }
        public event Action<string, string> ActionClicked;   // (reference, button text)

        public QueueCard(string reference, string name, string service,
                         string time, string queueNo, string status)
        {
            BookingRef = reference;
            BackColor = Color.White;
            Height = 90;
            Margin = new Padding(0, 0, 0, 10);

            Controls.Add(new Label
            {
                Text = queueNo,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 74, 162),
                Location = new Point(16, 28),
                AutoSize = true
            });
            Controls.Add(new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(100, 14),
                AutoSize = true
            });
            Controls.Add(new Label
            {
                Text = service + "  •  " + time,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Location = new Point(100, 40),
                AutoSize = true
            });
            Controls.Add(new Label
            {
                Text = reference,
                Font = new Font("Consolas", 8F),
                ForeColor = Color.Gray,
                Location = new Point(100, 60),
                AutoSize = true
            });

            FlowLayoutPanel buttons = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                Width = 150,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(0, 10, 12, 0),
                BackColor = Color.Transparent
            };
            Controls.Add(buttons);

            switch (status)
            {
                case "Booked":
                    buttons.Controls.Add(MakeButton("Check In", Color.FromArgb(11, 74, 162)));
                    buttons.Controls.Add(MakeButton("No-Show", Color.Red));
                    break;
                case "Checked In":
                    buttons.Controls.Add(MakeButton("Add to Waiting", Color.FromArgb(11, 74, 162)));
                    buttons.Controls.Add(MakeButton("No-Show", Color.Red));
                    break;
                case "Waiting":
                    buttons.Controls.Add(MakeButton("Call Next", Color.FromArgb(11, 74, 162)));
                    buttons.Controls.Add(MakeButton("No-Show", Color.Red));
                    break;
                case "Called":
                    buttons.Controls.Add(MakeButton("Start Serving", Color.FromArgb(11, 74, 162)));
                    buttons.Controls.Add(MakeButton("No-Show", Color.Red));
                    break;
                case "Being Served":
                    buttons.Controls.Add(MakeButton("Complete", Color.FromArgb(27, 127, 59)));
                    break;
            }
        }

        private RoundedButton MakeButton(string text, Color color)
        {
            RoundedButton b = new RoundedButton
            {
                Text = text,
                BackColor = color,
                ForeColor = Color.White,
                Size = new Size(130, 32),
                CornerRadius = 8,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Margin = new Padding(0, 0, 0, 6)
            };
            b.Click += (s, e) => ActionClicked?.Invoke(BookingRef, text);
            return b;
        }
    }
}