import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>olá!</h1>
        <p>clique em produtos para ver os produtos cadastrados:</p>
      </div>
    );
  }
}
