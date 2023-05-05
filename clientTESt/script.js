let b1 = document.getElementById("pseudo");
let b2 = document.getElementById("mdp");
let s1 = document.getElementById("log");

function log() {
    fetch("http://localhost:8000/api/User/GetAll")
    .then(function(res) {
        return res.json()
    })
    .then(function(data) {
        console.log(data)
    })
    let g1 = document.getElementById("g1");
    g1.innerHTML ="Good connected"
}

async function getAllPokemon() {
    for(i = 1; i <= 900; i++){
        let pokemon = await getPokemonInfo(i)

        let data = {
            pkmId: pokemon.id,
            pkmName: pokemon.name,
            pkmImgUrl: pokemon.sprites.other.home.front_default
        }
    await fetch("http://localhost:8000/api/Pokemon", {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  })
  .then(response => {
    if (response.ok) {
      // la requête a réussi
    } else {
      // la requête a échoué
    }
    console.log(response)
  })
  .catch(error => {
    console.error('Erreur:', error);
  });
  
    }
}

async function getPokemonInfo(i){
    return await fetch('https://pokeapi.co/api/v2/pokemon/'+i)
    .then(resp => {
        return resp.json()
    })
    .then(value => {
        console.log(value.sprites.other.home);
        return value;
    })
}