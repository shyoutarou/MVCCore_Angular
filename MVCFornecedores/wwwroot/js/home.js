  var theForm =document.getElementById("theForm");
  theForm.hidden = true;

  var button = document.getElementById("buyButton");
  button.addEventListener("click", function () {
    alert("Buying...");
  });

  var listItems = document.getElementsByClassName("product-info");
  listItems[0].addEventListener("click", function () {
    alert("prodList");
  });
