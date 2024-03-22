async function getCollect() {
    response = await fetch("/api/Home/index", {
        method: "GET",
        mode: 'no-cors',
        headers: { "Accept": "application/json" }
    });
    res = response.json();
    createTable(res);
    
}


$.ajax({
    url: '/api/Home/index',
    type: 'GET',
    contentType: 'application/json',
    /* data: JSON.stringify(data), */
    success: function(response) {
       createTable(response)
    }
});

function createTable(data) {
    table = document.querySelector('table')
    tbody = document.querySelector('tbody')
    for(var i = 0; i < data.length; i++) {
        tr = document.createElement('tr');
        td = document.createElement('td');
        
        td.textContent = data[i].imageUrl;
        tr.appendChild(td);

        td = document.createElement('td');
        //td.innerHTML = `<a id='${data[i].id}' href="items.html/${data[i].id}" onclick='getItems(this)'>${data[i].name}</a>`
        td.innerHTML = `<input onclick=getItems(this) type='button' id='${data[i].id}' value=${data[i].name}>`
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].description;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].items.length;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].contentType;
        tr.appendChild(td);

        tbody.appendChild(tr);
    }

    table.appendChild(tbody);
    document.body.appendChild(table);
}
function createTableItems(data) {
    var table = document.createElement('table');
    table.className = 'table container';
    table.id = 'myTable';
    var thead, tbody;
    document.body.removeChild(document.body.lastChild); // удаляем старую таблицу

    thead = document.createElement('thead');
    tr = document.createElement('tr');



    td = document.createElement('th');
    td.textContent = 'Name';
    tr.appendChild(td);

    td = document.createElement('th');
    td.textContent = 'Description';
    tr.appendChild(td);

    td = document.createElement('th');
    td.textContent = 'Comments';
    tr.appendChild(td);

    td = document.createElement('th');
    td.textContent = 'Likes';
    tr.appendChild(td);

    thead.appendChild(tr);
    table.appendChild(thead);

    tbody = document.createElement('tbody');
    for (var i = 0; i < data.length; i++) {
        tr = document.createElement('tr');


        td = document.createElement('td');
        td.innerHTML = `<input onclick=getItems(this) type='button' id='${data[i].id}' value=${data[i].name}>`
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].description;
        tr.appendChild(td);

        //td = document.createElement('td');
        //td.textContent = data[i].comments.length;
        //tr.appendChild(td);

        //td = document.createElement('td');
        //td.textContent = data[i].likes.length;
        //tr.appendChild(td);

        tbody.appendChild(tr);
    }

    table.appendChild(tbody);
    document.body.appendChild(table);
}
function getItems(item)
{
    $.ajax({
        url: `/api/Home/${item.id}`,
        type: 'GET',
        contentType: 'application/json',
        success: function (response) {
            console.log(response);
            createTableItems(response)
        }
    });
}

