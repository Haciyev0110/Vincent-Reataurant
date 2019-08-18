$(function () {
    $(document).on("click", ".productBasket", function (a) {


        //alert($(this).data("proid"))
        var proId = $(this).data("proid");

        if ($(".sizeselector")) {
            sizeid = $(".sizeselector").val();
        }
        else {
            sizeid = 2;
        }

        $.ajax({
            url: "/AJAX/Addtobasket",
            type: "GET",
            dataType: "json",
            data: { "productId": proId, "sizeid": sizeid },
            success: function (res) {


                var count = res.data.length;
                let pri = 0;

                for (var i = 0; i < res.data.length; i++) {
                    pri += res.data[i].Subtotal;
                }


                $(".num").text(count);
                $(".cash").text("$" + pri.toFixed(2));
                $(".itemcart").text(count + "  item - View Cart");


            }
        });

        //var productId = $(this).attr('data-proid');


        //$.ajax({

        //    url: "/AJAX/AddtoBasket",
        //    data: { productId: productId },
        //    datatype: "json",
        //    success: function (res) {
        //        console.log(res)
        //    }
        //})




    });
    $(document).on("click", ".deletproduc", function (e) {


        var proId = $(this).data("proid");
        var product = $(this).parent().parent();



        $.ajax({
            url: "/AJAX/DeleteProduct",
            type: "POST",
            dataType: "json",
            data: { "id": proId },
            success: function (res) {
                product.remove();

                var count = res.length;
                var f = 0.00;

                for (var i = 0; i < res.length; i++) {
                    f += res[i].Price;
                }

                $(".proprice").html("Subtotal   $  " + f.toFixed(2));
                $(".cash").text("$" + f.toFixed(2));
                $(".itemcart").text(count + "  item - View Cart");
                $(".num").text(count);

            }
        })
    });

    $(document).on("change", ".outp", function (b) {
        var sum = 0;
        var proId = $(this).data("proid");
        var count = $(this).val();
        var output = $(this);
        var proPrice = $(this).data("proprice");
        var subtotal = document.querySelectorAll(".vmf");



        $.ajax({
            url: "/AJAX/UptadeProduct",
            type: "POST",
            dataType: "json",
            data: { "id": proId, "changeCount": count },
            success: function (res) {

                var f = count * proPrice;
                var totatlPrc = output.parent().next().html("$" + f.toFixed(2))

                output.parent().next().attr("data-subtotal", f.toFixed(2))

                for (var i = 0; i < subtotal.length; i++) {
                    sum += parseInt( subtotal[i].getAttribute("data-subtotal"))
                }

                //console.log(sum)
                $(".proprice").html("Subtotal $" + sum.toFixed(2))
                $(".cash").html("$" + sum.toFixed(2))
               
                }




            });

    });

})