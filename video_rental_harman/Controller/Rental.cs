using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace video_rental_harman.Controller
{
   public class Rental:dbClass
    {
        public int rentID { get; set; }
        public String frstName { get; set; }
        public String lastName { get; set; }
        public String title { get; set; }
        public String bookingDate { get; set; }
        public String returnDate { get; set; }

        public Rental()
        {

        }
        public Rental(int id,String fName,String lName,String tit,String bDate,String rDate) {
                
        }


        //this method is used to pass the value from front end to back end 
        public void passValueToDatabase(String Query, String format)
        {
            try
            {
                if (format.Equals("Issue"))
                {
                    InsertDeleteUpdate(Query);
                }
                else if (format.Equals("Return"))
                {
                    InsertDeleteUpdate(Query);
                }
                
                else
                {
                    MessageBox.Show("Check Data Properly ");
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show("Check data Once Again ");
            }

        }

    }
}
