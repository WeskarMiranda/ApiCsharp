import { useEffect, useState } from "react";

interface Produto {
    id: string;
    nome: string;
    preco: number;
    quantidade: number;
}

function ConsultarProdutos() {
    const [produtos, setProdutos] = useState<Produto[]>([]);

    useEffect(() => {
        consultarProdutos();
    }, []);

    function consultarProdutos() {
        fetch("http://localhost:5117/api/produto/listar")
            .then(resposta => resposta.json())
            .then(data => {
                setProdutos(data); 
            })
            .catch(error => {
                console.error("Erro ao consultar produtos:", error);
            });
    }

    return (
        <div>
            <h1>Lista de Produtos</h1>
            <ul>
                {produtos.map(produto => (
                    <li key={produto.id}>
                        <strong>ID:</strong> {produto.id}<br />
                        <strong>Nome:</strong> {produto.nome}<br />
                        <strong>Preço:</strong> R$ {produto.preco.toFixed(2)}<br />
                        <strong>Quantidade:</strong> {produto.quantidade}<br />
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default ConsultarProdutos;




// import { useEffect, useState } from "react";

// interface Produto {
//     id: string;
//     nome: string;
//     preco: number;
//     quantidade: number;
// }

// function ConsultarProdutos() {
//     // Estado tipado como uma lista de Produto
//     const [produtos, setProdutos] = useState<Produto[]>([]);

//     useEffect(() => {
//         fetch("http://localhost:5117/api/produto/listar") // Exemplo de endpoint
//             .then((resposta) => resposta.json())
//             .then((data: Produto[]) => setProdutos(data)) // Tipando a resposta
//             .catch((error) => console.error("Erro:", error));
//     }, []);

//     return (
//         <div>
//             <h1>Lista de Produtos</h1>
//             <ul>
//                 {produtos.map((produto) => (
//                     <li key={produto.id}>
//                         <strong>{produto.nome}</strong> - R${produto.preco.toFixed(2)}
//                     </li>
//                 ))}
//             </ul>
//         </div>
//     );
// }

// export default ConsultarProdutos;
