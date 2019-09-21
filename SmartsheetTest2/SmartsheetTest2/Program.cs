using System;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Linq;
using System.Collections.Generic;

namespace SmartsheetTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            String accessToken = "13jxiyjau34mt8snl33sh0zcz9";
            SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();
            

            UserProfile userProfile = smartsheet.UserResources.GetCurrentUser();
            Console.WriteLine($"The access token in use belongs to: {userProfile.FirstName} {userProfile.LastName}, {userProfile.Role}.");

            PaginatedResult<Sheet> sheetsAvailable = smartsheet.SheetResources.ListSheets(null, null, null);
            Console.WriteLine($"This access token has access to {sheetsAvailable.TotalCount} sheets.");
            Console.WriteLine($"Press ENTER for a list of sheets.");
            Console.ReadLine();

            IEnumerable<int> rowsToGet = new[] {0,2, 3, 4, 25, 26, 27 };
            
           foreach (Sheet mySheet in sheetsAvailable.Data)
                {
                Sheet blatSheet = smartsheet.SheetResources.GetSheet((long)mySheet.Id, null, null, null, null, null, null, null);

                if (blatSheet.Rows.Count > 3)
                {
                    Console.WriteLine(blatSheet.Rows[0].Id);
                }

                //Row blatRow = smartsheet.SheetResources.RowResources.GetRow((long)mySheet.Id, (long)mySheet.Rows[3].Id,null, null);
                //Console.WriteLine(blatRow.Cells[3].DisplayValue);
               
                /*
                if (blatSheet.Columns.Count >= 4)
                {
                    if (blatSheet.Columns[3].Title == "Details")
                    {
                        Console.WriteLine(blatSheet.Name);
                        Console.WriteLine(blatSheet.Rows[3].Cells[3].Value);
                        Console.WriteLine(blatSheet.Rows[26].Cells[3].DisplayValue);
                        

                    }
                    
                }
                */
               
                
           //This is a test comment
                    
               

            }

            //int sheetIDToRead = 2;

           

            /*PaginatedResult<Column> columnsAvailable = smartsheet.SheetResources.ColumnResources.ListColumns(sheetsAvailable.Data[sheetIDToRead].Id, null, null);
            //PaginatedResult<Row> rowsAvailable = smartsheet.SheetResources.RowResources.

            Console.WriteLine(smartsheet.SheetResources.RowResources.CellResources.ToString(
                sheetsAvailable.Data[sheetIDToRead].Id,  // long sheet ID
                  // long row ID
                     // long column ID


                )
                );*/
            

            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();






        }
    }
}
