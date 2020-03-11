import React, { Component } from 'react';

export class ProductList extends Component {
  static displayName = ProductList.name;

  constructor(props) {
    super(props);
    
    this.state = { products: [], loading: true };
  }

  componentDidMount() {
    
    this.populateProductData();
  }

  static renderProductsTable(productsList) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Código</th>
            <th>Nome</th>
            <th>Valor</th>
          </tr>
        </thead>
        <tbody>
          {productsList.map(product =>
              <tr key={product.code }>
                <td>{product.code }</td>
                <td>{product.name}</td>
                <td>{product.value}</td>
              </tr>
           )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading ? <p><em>carregando...</em></p>
      : ProductList.renderProductsTable(this.state.products);
      
    return (
      <div>
        <h1 id="tabelLabel" >Produtos cadastrados</h1>
        {contents}
      </div>
    );
  }

  async populateProductData() {
    const response = await fetch('https://localhost:5001/api/products');
    
    const data = await response.json();
    
    console.log(data);
    
    this.setState({ products: data, loading: false });
  }
}
