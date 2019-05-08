var city
var infoText
var weatherPicSrc
var time = new Date()
var temp
var minTemp
var maxTemp
var humidity
var pressure

Date.prototype.addHours = function(h) {    
    this.setTime(this.getTime() + (h*60*60*1000)); 
    return this;   
 }

function getNewLiHtml(){
    return `<li class="weather-info">
    <article>
      <header>
        <figure><img class="weather-pic" src="${weatherPicSrc}" alt=""></figure>
        <address>
          <p>${city}</p>
        </address>
        <time>${time}</time>
      </header>
      <div class="weather-info-text">
        <p><strong>${infoText}</strong> | temp: ${temp} &#8451; | min temp ${minTemp} &#8451; | max temp ${maxTemp} &#8451; | Humidity: ${humidity} % | Pressure: ${pressure} bar</p>
      </div>
    </article>
    </li>`
}

function appendWeatherInfoLiItems(){
    var parent = $("#weather-info-list")
    var response;

    var weatherInfoCnt = 0
    $.ajax(
        {
            type: 'GET',
            url: "https://api.openweathermap.org/data/2.5/group?id=727011,728193,1701668,1688253,1696177&units=metric&lang=bg&APPID=2630aa0850490a8829b1df0a18812a04",
        })
    .done(function(resp) {
        response = resp
        console.dir(resp)
    })
    .fail(function(resp) {
        response = -1
        console.log("FAIL")
        console.dir(resp)
    })
    .always(function() {
        if(response == -1) return

        var i;
        for (i = 0; i < response.cnt; i++) { 
            city = `${response.list[i].name}, ${response.list[i].sys.country}`
            infoText = response.list[i].weather[0].description

            humidity = response.list[i].main.humidity
            pressure = response.list[i].main.pressure
            temp = response.list[i].main.temp
            maxTemp = response.list[i].main.temp_max
            minTemp = response.list[i].main.temp_min

            weatherPicSrc = `../images/demo/weather/${response.list[i].weather[0].icon}.png`

            parent.append(getNewLiHtml())
            if (i == 1){
                time.addHours(5)
            }
        }
      });
}


appendWeatherInfoLiItems()