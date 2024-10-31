
import { useEffect, useState } from "react";

function ConsultarCEP(){

    const [cep, setCep] = useState("");
    const [bairro, setBairro] = useState("");
    const [localidade, setLocalidade] = useState("");
    const [logradouro, setLogradouro] = useState("");

    useEffect(() => {
        //Método utilizado para executar qualquer código enquanto
        //o componente está sendo aberto ou renderizado
        //Biblioteca de requisições - AXIOS
        
    });

    function consultarCep() {
        fetch("https://viacep.com.br/ws/"+ cep + "/json/")
            .then(resposta => resposta.json())
            .then(endereco => {
                setBairro(endereco.bairro);
                setLocalidade(endereco.localidade);
                setLogradouro(endereco.logradouro);
            });

    }

    function modificar(event : any){
        setCep(event.target.value);
    }

    

    function clicar(){
        fetch("https://viacep.com.br/ws/"+ cep + "/json/")
            .then(resposta => resposta.json())
            .then(endereco => {
                setBairro(endereco.bairro);
                setLocalidade(endereco.localidade);
                setLogradouro(endereco.logradouro);
            });
    }

    function pederFoco(){
        consultarCep();
    }

    return(
        <div>
            <h1>Consultar CEP</h1>
            <input type="text" 
            placeholder="Digite um CEP"
            onChange={modificar}
            onBlur={pederFoco}
            />
            <button onClick={clicar}>Consultar CEP</button>
            <p>{bairro}</p>
            <p>{localidade}</p>
            <p>{logradouro}</p>
        </div>
    );
}

export default ConsultarCEP;

// import { useEffect, useState } from "react";
// import axios from "axios";

// interface CepData {
//     cep: string;
//     logradouro: string;
//     bairro: string;
//     localidade: string;
//     uf: string;
// }

// function ConsultarCep() {
//     const [cepData, setCepData] = useState<CepData | null>(null);

//     useEffect(() => {
//         const fetchCepData = async () => {
//             try {
//                 const resposta = await axios.get<CepData>("https://viacep.com.br/ws/01001000/json/");
//                 setCepData(resposta.data);
//             } catch (error) {
//                 console.error("Erro ao buscar o CEP:", error);
//             }
//         };

//         fetchCepData();
//     }, []);

//     return (
//         <div>
//             <h1>Consultar CEP</h1>
//             {cepData ? (
//                 <div>
//                     <p><strong>CEP:</strong> {cepData.cep}</p>
//                     <p><strong>Logradouro:</strong> {cepData.logradouro}</p>
//                     <p><strong>Bairro:</strong> {cepData.bairro}</p>
//                     <p><strong>Cidade:</strong> {cepData.localidade}</p>
//                     <p><strong>Estado:</strong> {cepData.uf}</p>
//                 </div>
//             ) : (
//                 <p>Carregando...</p>
//             )}
//         </div>
//     );
// }

// export default ConsultarCep;

// import { useEffect, useState } from "react";

// interface CepData {
//     cep: string;
//     logradouro: string;
//     bairro: string;
//     localidade: string;
//     uf: string;
// }

// function ConsultarCep() {
//     // Tipamos o estado para que seja do tipo CepData ou null
//     const [cepData, setCepData] = useState<CepData | null>(null);

//     useEffect(() => {
//         fetch("https://viacep.com.br/ws/01001000/json/")
//             .then((resposta) => resposta.json())
//             .then((data: CepData) => setCepData(data)) // Usamos o tipo CepData
//             .catch((error) => console.error("Erro ao buscar o CEP:", error));
//     }, []); // Executa apenas uma vez após a montagem do componente

//     return (
//         <div>
//             <h1>Consultar CEP</h1>
//             {cepData ? ( // Exibe os dados se o estado não for null
//                 <div>
//                     <p><strong>CEP:</strong> {cepData.cep}</p>
//                     <p><strong>Logradouro:</strong> {cepData.logradouro}</p>
//                     <p><strong>Bairro:</strong> {cepData.bairro}</p>
//                     <p><strong>Cidade:</strong> {cepData.localidade}</p>
//                     <p><strong>Estado:</strong> {cepData.uf}</p>
//                 </div>
//             ) : (
//                 <p>Carregando...</p>
//             )}
//         </div>
//     );
// }

// export default ConsultarCep;

// Exercicios
// exibir os dados do cep no html
// realizar a requisição para a sua api
// resolver o problema de cors na api
//exibir a lista de produtos no html