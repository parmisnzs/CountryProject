$(document).ready(function () {

    $("#GetallData").click(function () {
        debugger
        $.ajax({

            url: 'https://restcountries.com/v2/all',
            dataType: "json",
            type: "Get",
            //contentType: 'application/json; charset=utf-8',  
            //data: {Id:Id},  
            success: function (data) {
                var tr;
                console.log(data);
                debugger
                //for (var i = 0; i < data.length; i++) {  
                //    tr = tr + "<tr>";  
                //    tr = tr + "<td>" + data[i].Id + "</td>";  
                //    tr = tr + "<td>" + data[i].CustomerName + "</td>";  
                //    tr = tr + "<td>" + data[i].Address + "</td>";  
                //    tr = tr + "<td>" + data[i].City + "</td>";  
                //    tr = tr + "<td>" + data[i].Pincode + "</td>";  
                //    tr = tr + "</tr>";  
                //}  
                //$('#tblPopulation').append(tr);  
                //tblFormate();  
            },
            error: function (xhr) {
                alert('No Valid Data');
            }
        });
    });
});