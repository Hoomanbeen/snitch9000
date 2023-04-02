import React from "react";
import 'bootstrap/dist/css/bootstrap.css';
  
const Tool = () => {
  return (
    <div id="home" className="container-fluid home" style={{ padding: "150px 40px" }}>
    <div id="tool" className="container-fluid tool" style={{padding:"100px 40px"}}>
    <h1>Use Snitch 9000</h1>
    <div className="container-fluid">
        <div className="row">
            <div className="col-sm-6">
                <p>
                <span className="badge bg-danger">4</span>
                &nbsp;Instances found!
                </p>
                <ul className="list-group" style={{padding:"0px 0px", overflow: "scroll", height:"150px", width:"100%"}}>
                    <li className="list-group-item">First item</li>
                    <li className="list-group-item">Second item</li>
                    <li className="list-group-item">Third item</li>
                    <li className="list-group-item">Fourth item</li>
                </ul> 
            </div>
            <div className="col-sm-6">
                <form>
                    <div className="mb-3 mt-3">
                    <label for="input">Enter question information here:</label>
                    </div>
                    <div class="form-group">
                    <label for="usr">Title:</label>
                    <input type="text" class="form-control" id="usr"></input>
                    </div>
                    <div class="form-group">
                    <label for="pwd">Content:</label>
                    <input type="text" class="form-control" id="pwd"></input>
                    </div> 
                    <div class="form-group">
                        <label for="sel1">Course Select</label>
                        <select class="form-control" id="sel1">
                        </select>
                    </div> 
                    <br></br>
                    <button type="submit" className="btn btn-primary">Submit</button>
                </form>
                </div>
            </div>
        </div> 
    </div>
    </div>
  );
};
  
export default Tool;