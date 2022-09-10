$( document ).ready(function() {
    //make heart full on click
$(".fa").click(function(event) {
    $(this).toggleClass('fa fa-heart').toggleClass('fa fa-heart-o');
});

//change card class to flipped by clicking button
//card is parent of a button
$('.btn').click(function(){  $(this).parent().parent().parent().parent().toggleClass("flipped");
});

$('.back-btn').click(function(){  $(this).parent().parent().toggleClass("flipped");
});
});
