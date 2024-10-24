import { useEffect } from "react";

function ConsultarCep(){

    useEffect(() => {
        // Metodo do utilizado para executar enquanto o componente esta sendo aberto ou renderizado
        fetch("https://viacep.com.br/ws/01001000/json/")
        .then(resposta => {
            return resposta.json();
        })
        .then(cep => {
            console.log(cep);
        })
    });

    return(
        <div>
            <h1>ConsultarCep</h1>
            
        </div>
        
    );

}

export default ConsultarCep;

// Exeercicios
// exibir os dados do cep no html
// realizar a requisição para a sua api
// resolver o problema de cors na api
//exibir a lista de produtos no html