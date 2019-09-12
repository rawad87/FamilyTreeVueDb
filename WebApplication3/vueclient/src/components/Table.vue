<template>   
   <div class="content" id="table">
   </div> 
</template>
<script>
import axios from 'axios'
function test()
{
    axios.get('/api/people').then(function (response)
    {
        test2(response.data);
    });
}
function test2(x)
{
    var arraylength = x.length;
    for(var i = 0; i < arraylength; i++)
    {
        document.getElementById('table').innerHTML += '<div> Navn: ' + x[i].firstName + ' </div>';
    }
}
test();
export default {
  name: 'Table',
  data () {
    return {    }
  }
}
</script>
