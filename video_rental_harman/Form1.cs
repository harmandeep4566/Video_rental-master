using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace video_rental_harman
{
    public partial class Form1 : Form
    {
        // create the object of the Movie Class 
        Controller.Movie instanceMovie = new Controller.Movie();

        // create the object of the Customer Class 
        Controller.Customer instanceCustomer = new Controller.Customer();

        // create the object of the Customer Class 
        Controller.Rental instanceRental = new Controller.Rental();

        String bookingDate = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        //this code is used to reset all session of the movie
        public void ClearMovie() {

            txtMovieCopies.Text = "";
            txtMovieGenre.Text = "";
            txtMovieName.Text = "";
            txtMoviePlot.Text = "";
            txtMovieRating.Text = "";
            txtMovieYear.Text = "";
            txtRentalCost.Text = "";
            lblMovieID.Text = "";

             

        }


        public void clearCustomer() {
            lblCustomerID.Text = "";
            txtCustomerFirstName.Text = "";
            txtCustomerLastName.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerPhone.Text = "";
                
        }
        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            //this method is used to pass the value from the user to the database 
            if (txtMovieName.Text.Equals("") && txtMoviePlot.Text.Equals("") && txtMovieGenre.Text.Equals("") && txtMoviePlot.Text.Equals("") && txtMovieCopies.Text.Equals("") && txtMovieRating.Text.Equals("") && txtMovieYear.Text.Equals(""))
            {
                MessageBox.Show("Fill all values ");
            }
            else { 
                instanceMovie = new Controller.Movie(1,txtMovieName.Text,txtMoviePlot.Text,txtMovieGenre.Text,Convert.ToInt32(txtMovieYear.Text),Convert.ToInt32(txtMovieCopies.Text),txtMovieRating.Text,txtRentalCost.Text);

                String Insert = "insert into MovieData(Title,Plot,Genre,Year,Copies,Ratting,Price) values('"+txtMovieName.Text+"','"+txtMoviePlot.Text+"','"+txtMovieGenre.Text+"',"+Convert.ToInt32(txtMovieYear.Text)+","+Convert.ToInt32(txtMovieCopies.Text)+",'"+txtMovieRating.Text+"','"+txtRentalCost.Text+"')";

                instanceMovie.passValueToDatabase(Insert,"Add");
                MessageBox.Show("Movie Record is inserted ");
                ClearMovie();
            }
           
        }

        private void btnClearMovie_Click(object sender, EventArgs e)
        {
            ClearMovie();
        }

        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            //this method is used to pass the value from the user to the database 
            
            if (txtMovieName.Text.Equals("") && txtMoviePlot.Text.Equals("") && txtMovieGenre.Text.Equals("") && txtMoviePlot.Text.Equals("") && txtMovieCopies.Text.Equals("") && txtMovieRating.Text.Equals("") && txtMovieYear.Text.Equals(""))
            {
                MessageBox.Show("Fill all values ");
            }
            else
            {
                instanceMovie = new Controller.Movie(1,txtMovieName.Text, txtMoviePlot.Text, txtMovieGenre.Text, Convert.ToInt32(txtMovieYear.Text), Convert.ToInt32(txtMovieCopies.Text), txtMovieRating.Text, txtRentalCost.Text);

                

                String Delete = "Delete from MovieData where ID="+instanceMovie.MovieID+"";

                instanceMovie.passValueToDatabase(Delete, "Delete");
                MessageBox.Show("Movie Record is Deleted ");
                ClearMovie();
            }

        }

        private void btnMovieData_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = instanceMovie.srchRecord("select * from MovieData");
            dgvMovies.DataSource = tbl;

        }

        private void txtMovieYear_TextChanged(object sender, EventArgs e)
        {
            //get the data difference to find the price 
            try {
                //get the current date 
                DateTime curntDate = DateTime.Now;
                //get the year
                int Year = curntDate.Year;

                int differnceYear = Year - Convert.ToInt32(txtMovieYear.Text);

                if (differnceYear>=0 && differnceYear<5) {
                    txtRentalCost.Text = "5";
                }
                if (differnceYear>5) {
                    txtRentalCost.Text = "2";
                }

            }
            catch (Exception ex) {
                    
            }
        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {

            //this method is used to pass the value from the user to the database 
            if (txtMovieName.Text.Equals("") && txtMoviePlot.Text.Equals("") && txtMovieGenre.Text.Equals("") && txtMoviePlot.Text.Equals("") && txtMovieCopies.Text.Equals("") && txtMovieRating.Text.Equals("") && txtMovieYear.Text.Equals(""))
            {
                MessageBox.Show("Fill all values ");
            }
            else
            {
                instanceMovie = new Controller.Movie(1,txtMovieName.Text, txtMoviePlot.Text, txtMovieGenre.Text, Convert.ToInt32(txtMovieYear.Text), Convert.ToInt32(txtMovieCopies.Text), txtMovieRating.Text, txtRentalCost.Text);

                String Edit = "update MovieData set Title'" + txtMovieName.Text + "',Plot='" + txtMoviePlot.Text + "',Genre='" + txtMovieGenre.Text + "',Year=" + Convert.ToInt32(txtMovieYear.Text) + ",Copies=" + Convert.ToInt32(txtMovieCopies.Text) + ",Ratting='" + txtMovieRating.Text + "',Price='" + txtRentalCost.Text + "'where ID=" + instanceMovie.MovieID + "";

                instanceMovie.passValueToDatabase(Edit, "Edit");
                MessageBox.Show("Movie Record is Updated ");
                ClearMovie();
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txtCustomerFirstName.Text.Equals("") && txtCustomerLastName.Text.Equals("") && txtCustomerAddress.Text.Equals("") && txtCustomerPhone.Text.Equals(""))
            {
                MessageBox.Show("FIll Proper Value to insert the record ");
            }
            else {
                instanceCustomer = new Controller.Customer(1,txtCustomerFirstName.Text,txtCustomerLastName.Text,txtCustomerAddress.Text,txtCustomerPhone.Text);
                String Insert = "insert into CustomerData (FrstName,LastName,Address,Phone) values('"+txtCustomerFirstName.Text+"','"+txtCustomerLastName.Text+"','"+txtCustomerAddress.Text+"','"+txtCustomerPhone.Text+"')";
                instanceCustomer.passValueToDatabase(Insert, "Add");
                MessageBox.Show("Customer Record is saved ");
                clearCustomer();
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {

            if (txtCustomerFirstName.Text.Equals("") && txtCustomerLastName.Text.Equals("") && txtCustomerAddress.Text.Equals("") && txtCustomerPhone.Text.Equals(""))
            {
                MessageBox.Show("FIll Proper Value to insert the record ");
            }
            else
            {
                instanceCustomer = new Controller.Customer(Convert.ToInt32(lblCustomerID.Text), txtCustomerFirstName.Text, txtCustomerLastName.Text, txtCustomerAddress.Text, txtCustomerPhone.Text);
                String Edit = "update CustomerData set FrstName='" + txtCustomerFirstName.Text + "',LastName='" + txtCustomerLastName.Text + "',Address='" + txtCustomerAddress.Text + "',Phone='" + txtCustomerPhone.Text + "' where ID="+ Convert.ToInt32(lblCustomerID.Text) + "";
                instanceCustomer.passValueToDatabase(Edit, "Edit");
                MessageBox.Show("Record is Updated Sucessfully ");
                clearCustomer();
            }


        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {

            if (txtCustomerFirstName.Text.Equals("") && txtCustomerLastName.Text.Equals("") && txtCustomerAddress.Text.Equals("") && txtCustomerPhone.Text.Equals(""))
            {
                MessageBox.Show("FIll Proper Value to insert the record ");
            }
            else
            {
                instanceCustomer = new Controller.Customer(Convert.ToInt32(lblCustomerID.Text), txtCustomerFirstName.Text, txtCustomerLastName.Text, txtCustomerAddress.Text, txtCustomerPhone.Text);
                String Delete = "delete CustomerData where ID=" + Convert.ToInt32(lblCustomerID.Text) + "";
                instanceCustomer.passValueToDatabase(Delete, "Delete");
                MessageBox.Show("Record is Deleted Sucessfully ");
                clearCustomer();
            }

        }

        private void btnCustomerRecord_Click(object sender, EventArgs e)
        {
            DataTable tblCustomer = new DataTable();
            tblCustomer = instanceCustomer.srchRecord("Select * from CustomerData");
            dgvCustomer.DataSource = tblCustomer;
        }

        private void btnRentalRecord_Click(object sender, EventArgs e)
        {
            //view the details of all rental record 
            DataTable tblRental = new DataTable();
            tblRental = instanceRental.srchRecord("Select * from RentalData");
            dgvRentals.DataSource = tblRental;

        }

        private void btnIssueMovie_Click(object sender, EventArgs e)
        {
            if (txtRentalsFN.Text.Equals("") && txtRentalsLN.Text.Equals("") && txtRentalsMovieTitle.Text.Equals(""))
            {
                MessageBox.Show("check the record ");
            }
            else {
                instanceRental = new Controller.Rental(1, txtRentalsFN.Text,txtRentalsLN.Text,txtRentalsMovieTitle.Text,DateTime.Now.ToShortDateString(),"Booked");
                String Insert = "insert into RentalData(FrstName,LastName,MovieTitle,BookingDate,ReturnDate) values ('"+txtRentalsFN.Text+"','"+txtRentalsLN.Text+"','"+txtRentalsMovieTitle.Text+"','"+DateTime.Now.ToShortDateString()+"','Booked')";
                instanceRental.passValueToDatabase(Insert, "Issue");
                MessageBox.Show("Movie is  Issued On rent ");
                lblRentalID.Text = "";
                txtRentalsFN.Text = "";
                txtRentalsLN.Text = "";
                txtRentalsMovieTitle.Text = "";

            }
        }

        private void btnReturnMovie_Click(object sender, EventArgs e)
        {
            if (txtRentalsFN.Text.Equals("") && txtRentalsLN.Text.Equals("") && txtRentalsMovieTitle.Text.Equals(""))
            {
                MessageBox.Show("check the record ");
            }
            else
            {
                //here i am going to check the details 
                DataTable tbl1 = new DataTable();
                tbl1 = instanceMovie.srchRecord("select * from MovieData where Title='" + txtRentalsMovieTitle.Text + "'");
                int sample = Convert.ToInt32(tbl1.Rows[0]["Copies"].ToString());

                //check the booking 
                DataTable tbl2 = new DataTable();
                tbl2 = instanceRental.srchRecord("select * from RentalData where Title='" + txtRentalsMovieTitle.Text + "' and ReturnDate='Booked'");
                int booking = Convert.ToInt32(tbl2.Rows.Count);
                if (booking < sample)
                {

                    //check the booking 
                    DataTable tbl3 = new DataTable();
                    tbl3 = instanceRental.srchRecord("select * from RentalData where FrstName='" + txtRentalsFN.Text + "' and ReturnDate='Booked'");
                    int counting = Convert.ToInt32(tbl3.Rows.Count);
                    if (counting >= 2)
                    {
                        MessageBox.Show("you can't book more videos ");
                    }
                    else
                    {


                        instanceRental = new Controller.Rental(Convert.ToInt32(lblRentalID.Text), txtRentalsFN.Text, txtRentalsLN.Text, txtRentalsMovieTitle.Text, DateTime.Now.ToShortDateString(), "Booked");
                        String Edit = "Update RentalData set FrstName='" + txtRentalsFN.Text + "',LastName='" + txtRentalsLN.Text + "',MovieTitle='" + txtRentalsMovieTitle.Text + "',BookingDate='" + bookingDate + "',ReturnDate='" + DateTime.Now.ToShortDateString() + "' where ID=" + Convert.ToInt32(lblRentalID.Text) + "";
                        instanceRental.passValueToDatabase(Edit, "Return");

                        //get the price of the booking 
                        DataTable tbl = new DataTable();
                        tbl = instanceMovie.srchRecord("select * from MovieData where Title='" + txtRentalsMovieTitle.Text + "'");
                        int cost = Convert.ToInt32(tbl.Rows[0]["Price"].ToString());

                        //get the difference 
                        DateTime start = Convert.ToDateTime(bookingDate);
                        DateTime endDate = DateTime.Now;

                        String diff2 = (endDate - start).TotalDays.ToString();
                        //convert the string value to double 
                        double d = Convert.ToDouble(diff2);
                        //pass the roud off value to calculate 
                        double days = Math.Round(d);
                        if (days == 0)
                        {
                            days = 1;
                        }
                        cost = Convert.ToInt32(days * cost);



                        MessageBox.Show("Movie is  Returned to the Store and charges is " + cost);






                    }


                }
                else {
                    MessageBox.Show("All copies are booked ");
                }

                




                lblRentalID.Text = "";
                txtRentalsFN.Text = "";
                txtRentalsLN.Text = "";
                txtRentalsMovieTitle.Text = "";

            }

        }

        private void rdbAllRented_CheckedChanged(object sender, EventArgs e)
        {
            //view the details of all rental record 
            DataTable tblRental = new DataTable();
            tblRental = instanceRental.srchRecord("Select * from RentalData where ReturnDate='Booked'");
            dgvRentals.DataSource = tblRental;

        }

        private void rdbOutRented_CheckedChanged(object sender, EventArgs e)
        {
            //view the details of all rental record 
            DataTable tblRental = new DataTable();
            tblRental = instanceRental.srchRecord("Select * from RentalData where ReturnDate<>'Booked'");
            dgvRentals.DataSource = tblRental;
        }

        private void dgvRentals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblRentalID.Text = dgvRentals.CurrentRow.Cells[0].Value.ToString();
            txtRentalsFN.Text = dgvRentals.CurrentRow.Cells[1].Value.ToString();
            txtRentalsLN.Text = dgvRentals.CurrentRow.Cells[2].Value.ToString();
            txtRentalsMovieTitle.Text = dgvRentals.CurrentRow.Cells[3].Value.ToString();
            bookingDate= dgvRentals.CurrentRow.Cells[4].Value.ToString();

        }

        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            clearCustomer();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCustomerID.Text = dgvCustomer.CurrentRow.Cells[0].Value.ToString();
            txtCustomerFirstName.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
            txtRentalsFN.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
            txtCustomerLastName.Text = dgvCustomer.CurrentRow.Cells[2].Value.ToString();
            txtRentalsLN.Text = dgvCustomer.CurrentRow.Cells[2].Value.ToString();
            txtCustomerAddress.Text = dgvCustomer.CurrentRow.Cells[3].Value.ToString();
            txtCustomerPhone.Text = dgvCustomer.CurrentRow.Cells[4].Value.ToString();
        }

        private void dgvMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMovieID.Text = dgvMovies.CurrentRow.Cells[0].Value.ToString();
            txtMovieName.Text = dgvMovies.CurrentRow.Cells[1].Value.ToString();

            txtRentalsMovieTitle.Text = dgvMovies.CurrentRow.Cells[1].Value.ToString();

            txtMoviePlot.Text = dgvMovies.CurrentRow.Cells[2].Value.ToString();
            txtMovieGenre.Text = dgvMovies.CurrentRow.Cells[3].Value.ToString();
            txtMovieYear.Text = dgvMovies.CurrentRow.Cells[4].Value.ToString();
            txtMovieCopies.Text = dgvMovies.CurrentRow.Cells[5].Value.ToString();
            txtMovieRating.Text = dgvMovies.CurrentRow.Cells[6].Value.ToString();
            txtRentalCost.Text = dgvMovies.CurrentRow.Cells[7].Value.ToString();

        }
    }
}
