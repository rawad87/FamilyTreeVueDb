<template>   
   <div class="content" id="table">
   </div> 
</template>
<script>
import axios from 'axios'
function FetchTable()
{
    axios.get('/api/people').then(function (response)
    {
        BuildTable(response.data);
    });
}
function BuildTable(x)
{
  var arraylength = x.length;
  var arrayKeys = Object.keys(x[0]);
  var keysLength = arrayKeys.length;
  var table = '<table><tr id="heading">';

  for(var i = 0; i < keysLength; i++)
  {
    table += '<th>' + arrayKeys[i] + ':</th>';
  }
  table += '<th>Edit:</th>'
  table += '<th>Delete:</th>'
  table += '</tr>'
  for(var i = 0; i < arraylength; i++)
  {
    var person = Object.keys(x[i]).map(function(key) {
    return [x[i][key]];});
    table += '<tr id="' + i + '">';
    person.forEach(element => 
    {
      table += '<td id="' + i + element +'">' + element +'</td>';
    });
    table += '<td><button type="button" id="' + i + '">Edit</button></td>';
    table += '<td><button type="button" id="' + i + '">Delete</button></td>';
    table += '</tr>';
  }
  table += '</table>';
  document.getElementById('table').innerHTML = table;
}
FetchTable();
export default {
  name: 'Table',
  data () {
    return {    }
  }
}
</script>
<style>
table
{
  border-collapse: collapse;
  margin: 0;
  color: black;
}
th 
{
  padding-right: 10px;
  border: solid black 2px;
  padding: 10px;
  margin: 0;
  background-color: darkgray;
  color: black;
}
td
{
  background-color: lightgray;
  border: solid black 2px;
}
</style>