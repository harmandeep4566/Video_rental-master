using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace video_rental_harman.Controller
{
   public class Customer : dbClass
    {
        public int CustomerID { get; set; }
        public String frstName { get; set; }
        public String lastName { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }

        public Customer(int id,String frName,String scName,String address,String phone) {
                
        }
        public Customer()
        {

        }

        //this method is used to pass the value from front end to back end 
        public void passValueToDatabase(String Query, String format)
        {
            try
            {
                if (format.Equals("Add"))
                {
                    InsertDeleteUpdate(Query);
                }
                else if (format.Equals("Edit"))
                {
                    InsertDeleteUpdate(Query);
                }
                else if (format.Equals("Delete"))
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
