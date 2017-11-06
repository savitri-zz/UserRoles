/* NUGET: BEGIN LICENSE TEXT
 *
 * Microsoft grants you the right to use these script files for the sole
 * purpose of either: (i) interacting through your browser with the Microsoft
 * website or online service, subject to the applicable licensing or use
 * terms; or (ii) using the files as included with a Microsoft product subject
 * to that product's license terms. Microsoft reserves all other rights to the
 * files not expressly granted by Microsoft, whether by implication, estoppel
 * or otherwise. Insofar as a script file is dual licensed under GPL,
 * Microsoft neither took the code under GPL nor distributes it thereunder but
 * under the terms set out in this paragraph. All notices and licenses
 * below are for informational purposes only.
 *
 * NUGET: END LICENSE TEXT */


$(document).ready(function () {
    $('#tblData').DataTable
    ({
        "columnDefs": [
          {
              "width": "5%",
              "targets": [0]
          },
          {
              "className": "text-center custom-middle-align",
              "targets": [0, 1, 2, 3, 4, 5, 6]
          }, ],
        "language":
        {
            "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
        },
        "processing": true,
        "serverSide": true,
        "ajax":
      {
          //"url": "/Plugin/GetData",
          "@url": "/Register",
          "type": "POST",
          "dataType": "JSON"
      },
        "columns": [
          {
              "data": "Sr"
          },
          {
              "data": "OrderTrackNumber"
          },
          {
              "data": "Quantity"
          },
          {
              "data": "ProductName"
          },
          {
              "data": "SpecialOffer"
          },
          {
              "data": "UnitPrice"
          },
          {
              "data": "UnitPriceDiscount"
          }]
    });
});
