import React from 'react'
import axios, {post} from 'axios';

export class UploadForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { file: null };
        
        this.onFormSubmit = this.onFormSubmit.bind(this);
        this.onChange = this.onChange.bind(this);
        this.fileUpload = this.fileUpload.bind(this);
    }
    
    onFormSubmit(e){
        e.preventDefault();
        
        this.fileUpload(this.state.file)
            .then((response)=>{
                console.log(response.data);
                alert("cadastrado com sucesso !!");
            })
    }
    
    onChange(e) {
        this.setState({ file: e.target.files[0]})
    }
    
    fileUpload(file){
        
        const url = 'https://localhost:5001/api/products';
        
        const formData = new FormData();
        
        formData.append('file',file);
        
        const config = {
            headers: { 'content-type': 'multipart/form-data' }
        };
        
        return post(url, formData,config)
    }

    render() {
        return (
            <form onSubmit={e => this.onFormSubmit(e)}>
                <h1>Envie em padrão csv</h1>
                <input type="file" onChange={e => this.onChange(e)} />
                <button type="submit">Upload</button>
            </form>
        );
    }
}