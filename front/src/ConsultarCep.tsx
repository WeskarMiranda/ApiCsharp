import { useEffect, useState } from "react";

interface CepData {
    cep: string;
    logradouro: string;
    bairro: string;
    localidade: string;
    uf: string;
}

function ConsultarCep() {
    // Tipamos o estado para que seja do tipo CepData ou null
    const [cepData, setCepData] = useState<CepData | null>(null);

    useEffect(() => {
        fetch("https://viacep.com.br/ws/01001000/json/")
            .then((resposta) => resposta.json())
            .then((data: CepData) => setCepData(data)) // Usamos o tipo CepData
            .catch((error) => console.error("Erro ao buscar o CEP:", error));
    }, []); // Executa apenas uma vez após a montagem do componente

    return (
        <div>
            <h1>Consultar CEP</h1>
            {cepData ? ( // Exibe os dados se o estado não for null
                <div>
                    <p><strong>CEP:</strong> {cepData.cep}</p>
                    <p><strong>Logradouro:</strong> {cepData.logradouro}</p>
                    <p><strong>Bairro:</strong> {cepData.bairro}</p>
                    <p><strong>Cidade:</strong> {cepData.localidade}</p>
                    <p><strong>Estado:</strong> {cepData.uf}</p>
                </div>
            ) : (
                <p>Carregando...</p>
            )}
        </div>
    );
}

export default ConsultarCep;

// Exercicios
// exibir os dados do cep no html
// realizar a requisição para a sua api
// resolver o problema de cors na api
//exibir a lista de produtos no html