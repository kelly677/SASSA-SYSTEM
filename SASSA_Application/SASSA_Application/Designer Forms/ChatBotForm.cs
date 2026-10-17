using System;
using System.Drawing;
using System.Windows.Forms;

namespace SASSA_Application.Designer_Forms
{
    public partial class ChatBotForm : Form
    {
        public ChatBotForm()
        {
            InitializeComponent();
        }

        private void ChatBotForm_Load(object sender, EventArgs e)
        {
            // Welcome message
            AddMessage("Assistant", "Hello! Ask me about bookings, your queue number, or contact details.");
        }

        // When the user clicks Send
        private void btnSend_Click(object sender, EventArgs e)
        {
            string userText = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

            // Show what the user typed
            AddMessage("You", userText);
            txtInput.Text="";

            // Get the bot's response
            string response = GetBotResponse(userText.ToLower());
            AddMessage("Assistant", response);
        }

        // Quick reply buttons (optional)
        private void btnQuickReply1_Click(object sender, EventArgs e)
        {
            txtInput.Text = "How do I book?";
            btnSend_Click(sender, e);
        }

        // --- THE BRAIN ---
        private string GetBotResponse(string query)
        {
            // Booking keywords
            if (query.Contains("book") || query.Contains("appointment"))
            {
                return "Click New Booking on the left menu, pick a centre, service, date and time, then confirm.";
            }
            // Cancel or Reschedule keywords
            else if (query.Contains("cancel") || query.Contains("reschedule") || query.Contains("change"))
            {
                return "Go to My Bookings, select the booking, and click either Reschedule or Cancel.";
            }
            // Queue status keywords
            else if (query.Contains("queue") || query.Contains("number") || query.Contains("waiting"))
            {
                return "Click Queue Status on the menu to see your number, status, and estimated wait.";
            }
            // Contact keywords
            else if (query.Contains("contact") || query.Contains("help") || query.Contains("phone") || query.Contains("email"))
            {
                return "You can call our helpline at 0800 000 123 or email help@sassa-demo.gov.za.";
            }
            // Greetings
            else if (query.Contains("hi") || query.Contains("hello") || query.Contains("hey"))
            {
                return "Hello! How can I assist you with your SASSA visit today?";
            }
            // Default fallback
            else
            {
                return "I'm not sure about that. Try asking about 'booking', 'queue', 'cancel', or 'contact'.";
            }
        }

        // --- UI HELPER TO MAKE IT LOOK LIKE A CHAT ---
        private void AddMessage(string sender, string message)
        {
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;

            // Set colors
            if (sender == "You")
            {
                rtbChat.SelectionColor = Color.DarkBlue;
                rtbChat.AppendText("\nYou: ");
                rtbChat.SelectionColor = Color.Black;
                rtbChat.AppendText(message + "\n");
            }
            else
            {
                rtbChat.SelectionColor = Color.DarkGreen;
                rtbChat.AppendText("\nAssistant: ");
                rtbChat.SelectionColor = Color.Black;
                rtbChat.AppendText(message + "\n");
            }

            // Auto-scroll to bottom
            rtbChat.ScrollToCaret();
        }
    }
}