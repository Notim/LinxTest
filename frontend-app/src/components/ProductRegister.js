import React, {Component} from 'react';
import {UploadForm} from './UploadForm';

export class ProductRegister extends Component {
    static displayName = ProductRegister.name;
    
    constructor(props) {
        super(props);
    }

    static renderScreen() {
        return (
            <div className="col-12">
                <UploadForm />
            </div>
        );
    }

    render() {
        return (
            <div>
                <h1 id="tabelLabel">Importação de dados de produtos</h1>
                {ProductRegister.renderScreen()}
            </div>
        );
    }
}
