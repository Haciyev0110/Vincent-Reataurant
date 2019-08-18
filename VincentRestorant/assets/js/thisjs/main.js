$(document).ready(function(as){

var activeLi = $('#ourMenu .discover .menukind ul li');
var container = $("#ourMenu .discover .preloaderback");
var SecondContainer = $("#ourMenu .discover .dataId1");



    

$(".recipes").css("display","none");
$(".recipes").first().css("display","block");


$(".menuList li").click(function(){
    var li=$(this)
    $(".recipes").each(function(){
        if ($(this).data("id")==$(li).data("id")) {
            $(this).css("display","block")
        }else{
            $(this).css("display","none")
            
        }
    
    })
})



})
$('.menukind li').click(function(){
$(this).addClass("active").siblings().removeClass("active")

})
$(window).scroll(function(){
    if($(window).scrollTop()>=195  &&    $(window).width()>=1024)   {
        $(".mobheader").css('display', 'block');
      }
    else{
        $(".mobheader").css('display', 'none');
        
    }

});$(window).scroll(function(){
    if($(window).scrollTop()>=195    &&    $(window).width()>=1024){
       $(".backtop").css('display','block');
      }
    else{
        $(".backtop").css('display','none');
    }

});


    $('.backtop').click(function(e){
    $("html, body").animate({ scrollTop: "0" });
    });

    // owl  slider  start//



    
    $('.owl-carousel').owlCarousel({
        items:1,
        margin:10,
        autoHeight:true
    });
    // owl  slider  end//

    $('#accrodinfirst .card').click(function(){
        $(this).addClass("active").siblings().removeClass("active")
        
        })
    $('.number li').click(function(){
        $(this).addClass("active").siblings().removeClass("active")
            
        })
        $('#a').click(function(e){
            e.preventDefault();
            // $( "li.active" ).removeClass('active');
            $( "li.active" ).next().addClass('active');
            $( "li.active" ).first().before().removeClass('active');


})


//let count = 0;

//$(".spanimage").click(function () {
//    count++;

//    $(".num").html(count);
//    $(".itemcart").html(count +" "+ "View  Cart");
//})

