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
                return "You can call our helpline at 0800 60 1011 or email sassaapplication642@gmail.com";
            }
            else if (query.Contains("password") || query.Contains("forgot") || query.Contains("reset") || query.Contains("otp"))
            {
                return "If you forgot your password, go back to the main Welcome screen, click 'Forgot Password?', and we will email you a 6-digit OTP to reset it.";
            }
            // --- NEW: Update Profile Picture ---
            else if (query.Contains("picture") || query.Contains("photo") || query.Contains("profile pic") || query.Contains("image") || query.Contains("avatar"))
            {
                return "To update your picture, go to the Profile tab on the left menu, click 'Upload Photo', select an image from your computer, and it will save automatically.";
            }
            // --- NEW: Operating Hours ---
            else if (query.Contains("hour") || query.Contains("open") || query.Contains("time") || query.Contains("close"))
            {
                return "Our operating hours are Monday to Friday, from 08:00 AM to 16:00 PM. We are closed on weekends and public holidays.";
            }
            // --- NEW: Thank you / Greetings ---
            else if (query.Contains("thank") || query.Contains("thanks") || query.Contains("awesome") || query.Contains("great"))
            {
                return "You're very welcome! Is there anything else I can help you with today?";
            }
            // Greetings
            else if (query.Contains("hi") || query.Contains("hello") || query.Contains("hey"))
            {
                return "Hello! How can I assist you with your SASSA visit today?";
            }
            else if (query.Contains("how are you") || query.Contains("howzit") || query.Contains("are you okay"))
            {
                return "I'm just a virtual assistant, so I'm always running perfectly! How can I help you today?";
            }
            else if (query.Contains("queue") || query.Contains("number") || query.Contains("waiting"))
            {
                if (query.Contains("long") || query.Contains("slow") || query.Contains("delay"))
                {
                    return "Queues can get long during month-end or when a new grant cycle opens. You can check your 'Estimated Wait' on the Queue Status page. If it's very long, you are welcome to reschedule for another day!";
                }
                return "Click Queue Status on the menu to see your number, status, and estimated wait.";
            }

            // 5. Address & Directions
            else if (query.Contains("address") || query.Contains("where is") || query.Contains("location") || query.Contains("directions") || query.Contains("find"))
            {
                return "You can find the physical address for your selected centre on your Booking Confirmation slip. If you need to change centres, you can do so by creating a new booking.";
            }

            // 6. Logging out
            else if (query.Contains("log out") || query.Contains("logout") || query.Contains("sign out") || query.Contains("exit"))
            {
                return "To keep your account safe, click the red 'Logout' button at the bottom left of the menu. This will take you back to the main welcome screen.";
            }
            else if (query.Contains("document") || query.Contains("bring") || query.Contains("id") || query.Contains("paperwork") || query.Contains("what must i bring"))
            {
                return "Please remember to bring your original South African ID book/card, proof of residence, and any relevant payslips or medical notes for the service you are booking.";
            }

            // Default fallback
            else
            {
                return "I'm not sure about that. Try asking about 'booking', 'queue', 'cancel', or 'contact'related questions.";
            }
        }

        // --- UI HELPER TO MAKE IT LOOK LIKE A CHAT ---
        private void AddMessage(string sender, string message)
        {
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;

            // Define the fonts (12pt for normal, 12pt Bold for names)
            Font nameFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            Font messageFont = new Font("Segoe UI", 12F, FontStyle.Regular);

            if (sender == "You")
            {
                // User Name
                rtbChat.SelectionFont = nameFont;
                rtbChat.SelectionColor = Color.DarkBlue;
                rtbChat.AppendText("\nYou:\n");

                // User Message
                rtbChat.SelectionFont = messageFont;
                rtbChat.SelectionColor = Color.Black;
                rtbChat.AppendText(message + "\n");
            }
            else
            {
                // Assistant Name
                rtbChat.SelectionFont = nameFont;
                rtbChat.SelectionColor = Color.DarkGreen;
                rtbChat.AppendText("\nAssistant:\n");

                // Assistant Message
                rtbChat.SelectionFont = messageFont;
                rtbChat.SelectionColor = Color.Black;
                rtbChat.AppendText(message + "\n");
            }

            // Auto-scroll to bottom
            rtbChat.ScrollToCaret();
        }
    }
}