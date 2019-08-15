window.addEventListener("load", setup);

let bodyNode;
let itemTemplateDiv;

let currentGameData = {
  TintedRocks: 0
};

function setup() {
  bodyNode = document.querySelector("body");
  itemTemplateDiv = document.getElementById("item-template");
  bodyNode.removeChild(itemTemplateDiv);

  let tintedMeter = document.getElementById("tinted-meter");
  tintedMeter.style.width = "0%";
  // window.addEventListener("click", grabData);
  window.setInterval(grabData, 1000);
  // setTintedWidth(55);
}

function grabData() {
  window.fetch("isaac.json")
    .then((resp) => {
      return resp.json();
    })
    .then((obj) => {
      if (currentGameData.TintedRocks <= 100 && currentGameData.TintedRocks != obj.TintedRocks) {
        currentGameData.TintedRocks = obj.TintedRocks;
        setTintedWidth(obj.TintedRocks);
      }
    })
    .catch((err) => {
      console.log(err);
    });
}

function setTintedWidth(numTintedRocks) {
  let tintedMeter = document.getElementById("tinted-meter")
  let tintedText = tintedMeter.nextElementSibling;

  tintedText.textContent = `${numTintedRocks}/100`;

  tintedMeter.style.width = `${numTintedRocks}%`;
  if (numTintedRocks > 99) {
    tintedMeter.style.backgroundImage = "linear-gradient(45deg, #696b14, #e6ea00)";
  }
}