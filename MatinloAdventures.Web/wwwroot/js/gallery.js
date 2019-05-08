var galleryDiv = $('#gallery');

var galleryImages = galleryDiv.find('img');
var imageSlider = $("#image-slider");
var imageSliderImage =  $("#image-slider-image");
var imageSliderButtons = imageSlider.find('button');

var slideIndex = 1;

// Hide image slider and its children by default
$( document ).ready(function() {
    closeSlider();

    // Attach an onclick event on each image in order to open the slider at correct index
    galleryImages.each(function(index) {
        console.dir($(this))
        $(this).click(function(){ showDivs(index); })
    });
});

function closeSlider() {
    console.log("Closing slider");
    
    imageSlider.hide();
    imageSlider.find('*').hide();
}

// ------------------------------- Slider logic -------------------------------
function plusDivs(n) {
    showDivs(slideIndex += n);
}

function showDivs(n) {
    console.log("Showing divs for " + n)
    console.dir(galleryImages[n])

    if (n >= galleryImages.length) {slideIndex = 0} 
    if (n < 0) {slideIndex = galleryImages.length - 1};

    var actualImage = $(galleryImages[slideIndex]);

    imageSliderImage.attr("src", actualImage.attr("src"));
    imageSlider.show();
    imageSlider.find('*').show();
}

