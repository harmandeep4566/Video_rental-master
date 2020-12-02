using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace video_rental_harman.Controller
{
    public class Movie: dbClass
    {

        public int MovieID { get; set; }
        public String MovieName { get; set; }
        public String Plot { get; set; }
        public String Genre { get; set; }
        public int Year { get; set; }
        public int Copies { get; set; }
        public String  Ratting { get; set; }
        public int Price { get; set; }

        public Movie() {

        }
        //constructor that is used to pass the value and pass the data to the data base 
        public Movie(int ID,String Name,String Plot,String genre,int Year,int Copies,String Ratting,String price) {
                
        }


        //this method is used to pass the value from front end to back end 
        public void passValueToDatabase(String Query, String format) {
           try {
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
                else {
                    MessageBox.Show("Check Data Properly ");
                }


           }
           catch (Exception ex) {
                //MessageBox.Show("Check data Once Again ");
            }
                
        }

    }
}
