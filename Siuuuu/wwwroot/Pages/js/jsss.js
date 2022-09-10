
  $(document).ready(function(){
  
    $('a').click(function(){
      $('a').removeClass("active");
      $(this).addClass("active");
    });
  });
  
$(document).ready(function(){
    $(window).scroll(function(){
        var scroll = $(window).scrollTop();
        if (scroll > 120) {
          $(".black").css("background" , "#181818de");
          $(".black").css("height" , "150px");


        }
  
        else{
            $(".black").css("background" , "none");  	
        }
    })
  })
  
