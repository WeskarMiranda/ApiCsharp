import { useEffect, useState } from "react";

interface Produto {
    id: string;
    nome: string;
    preco: number;
    quantidade: number;
}

function ConsultarProdutos() {
    // Estado tipado como uma lista de Produto
    const [produtos, setProdutos] = useState<Produto[]>([]);

    useEffect(() => {
        fetch("http://localhost:5117/api/produto/listar") // Exemplo de endpoint
            .then((resposta) => resposta.json())
            .then((data: Produto[]) => setProdutos(data)) // Tipando a resposta
            .catch((error) => console.error("Erro:", error));
    }, []);

    return (
        <div>
            <h1>Lista de Produtos</h1>
            <ul>
                {produtos.map((produto) => (
                    <li key={produto.id}>
                        <strong>{produto.nome}</strong> - R${produto.preco.toFixed(2)}
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default ConsultarProdutos;
