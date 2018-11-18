import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';



@Component({
  selector: 'app-root',
  templateUrl: './hoved.html',
  styleUrls: ['./app.component.css'],
})
export class hoved {
  title = 'app';
  showForm: boolean;
  visQaListe: boolean;
  alleQA: Array<Qa>; // for listen av alle QA
  form: FormGroup;
  laster: boolean;
  formStatus: string;
 

  


  constructor(private http: Http, private fb: FormBuilder) {
    this.form = fb.group({
      Id: [""],
      Type: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
      Question: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
    
     
    });
  }

  ngOnInit() {
    this.laster = true;
    this.hentQa();
    this.showForm = false;
    this.visQaListe = true;
  }


  Betaling() {
    this.http.get("/api/liste")
      .map(retur => retur.json())
      .subscribe(result => {
        this.alleQA = result;
        console.log(this.alleQA.length)
      }
      );
    this.visQaListe = true;
    
  }

  hentQa() {
    this.http.get("/api/Liste")
      .subscribe(
      JsonData => {
        this.alleQA = [];
          if (JsonData) {
            for (let qaObjekt of JsonData.json()) { // .json her
              this.alleQA.push(qaObjekt);
              this.laster = false;
            }
          };
        },
        error => alert(error),
        () => console.log("ferdig get-api/Qa")
      );
  };



  vedSubmit() {
    if (this.formStatus == "RegQa") {
      this.lagreQa();
    }
 
    else {
      alert("Feil i applikasjonen!");
    }
  }
  

  voteLike(id:number) {
   
  }
  voteDislike(id:number) {

  }

  home() {
    
    this.showForm = false;
    this.visQaListe = true;

  }
    newFa() {
      // må resette verdiene i skjema dersom skjema har blitt brukt til endringer

      this.form.setValue({
        Id: "",
        Type: "",
        Question: "",
     
      });
      this.form.markAsPristine();
      this.visQaListe = false;
      this.formStatus = "RegQa";
      this.showForm = true;
    }


    lagreQa() {
      var lagretFa = new Qa();

      lagretFa.Type = this.form.value.Type;
      lagretFa.Question = this.form.value.Question;
      

      var body: string = JSON.stringify(lagretFa);
      var headers = new Headers({ "Content-Type": "application/json" });

      this.http.post("api/Poste", body, { headers: headers })
       // .map(returData => returData.toString())
        .subscribe(
          retur => {
            this.hentQa();
            this.showForm = false;
            this.visQaListe = true;
          },
          error => alert(error),
          () => console.log("ferdig post-api/poste")
        );
    };

 
  
}

export class Qa {
  Id: number;
  Type: string;
  Question: string;
  Answer: string;
  Likes: number;
  Dislikes: number;
}
