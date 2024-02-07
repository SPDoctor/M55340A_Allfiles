function getWeather() {
    var uri = "/weatherforecast";
    fetch(uri)
        .then(response =>
            response.json())
        .then(data =>
            displayItems(data))
        .catch(error =>
            console.error('Unable to get items.', error));
}

function displayItems(data) {
    const forecast = document.getElementById('forecast');
    var html = "<tr><th width='20%'>Date</th><th>Temperature</th><th>Summary</th></tr>";
    html += data.map(day => tableRow(day));
    forecast.innerHTML = html;
}

function tableRow(day) {
    var html = "<tr>";
    html += "<td>" + day.date.substr(0, 10) + "</td>";
    html += "<td>" + day.temperatureC + "</td>";
    html += "<td>" + day.summary + "</td>";
    html += "</tr>";
    return html;
}
