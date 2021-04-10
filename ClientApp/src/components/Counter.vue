<template>
    <!--<h1>Counter</h1>

    <p>This is a simple example of an Vue component.</p>

    <p aria-live="polite">Current count: <strong>{{ currentCount }}</strong></p>

    <button class="btn btn-primary" @click="incrementCounter">Increment</button>-->
    <h1>Stylesheet1 test</h1>
    <h2>Style sheet 2 test</h2>
    <p v-if="errors.length">
        <b>please correct the following errors</b>
        <ul>
            <li v-for="error in errors" :key="error">
                {{error}}
            </li>
        </ul>
    </p>
    <form>
        <div class="col-sm-5">
            NAME : <input type="text" class="form-control" v-model="Name" name="Name" id="Name" /><br /><br />
        </div>
        <div class="col-sm-5">
            AGE : <input type="number" class="form-control" v-model="Age" name="Age" id="Age" /><br /><br />
        </div>
        <br />
        <div class="col-sm-5" v-if="!isEdit">
            <button type="button" @click="onSubmit" class="btn btn-primary">save</button>
        </div>
        <div class="col-sm-5" v-if="isEdit">
            <button type="button" @click="EditDetails" class="btn btn-primary">update</button>
        </div>
    </form>
    <div>
      <!--  <p>Data already in db is : {{datas}}</p>-->
        <!--<ul>
        <li v-for="value in datas">
            {{ value }}
        </li>
    </ul>-->
        <!--<ul>
            <li v-for='product in datas'>
                da2:  {{ product.name }}
            </li>
        </ul>-->
       
        <table style="width:100%" class="table table-striped">
           <thead>
               <tr>
                   <th>Name</th>
                   <th>Age</th>
               </tr>
           </thead>
            <tbody>
                <tr v-for="p in datas" :key="p">
                    <td>{{p.name}}</td>
                    <td>{{p.age}}</td>
                    <td><button type="button" class="btn btn-primary" @click="SeeDetails(p)">Edit</button></td>
                    <td><button type="button" class="btn btn-danger" @click="DeleteDetail(p)">Delete</button></td>

                </tr>
            </tbody>
        </table>
       
    </div>

</template>


<script lang="ts">
    import axios from "axios";

    export default {
        name: "Counter",
        data() {
            return {
                currentCount: 0,
                Age: '',
                Name: '',
                datas: {},
                isEdit: false,
                errors:[]
            }
        },
        mounted() {
            this.getDetails();
                      //axios.get('http://localhost:50598/api/details/GetAllDetails')
            //    .then((response) => {
            //        console.log("got data", response)
            //        this.datas = response.data;
            //        console.log("a", response.data)
            //        console.log("b", response.data[1])
            //    })
            //    .catch(function (error) {
            //        alert("error getting data!");
            //        console.log(error);
            //    })
        },
        methods: {
            incrementCounter() {
                this.currentCount++;
            },
            getDetails() {
                axios.get('http://localhost:50598/api/details/GetAllDetails')
                    .then((response) => {
                        console.log("got data", response)
                        this.datas = response.data;
                        console.log("a", response.data)
                        console.log("b", response.data[1])
                    })
                    .catch(function (error) {
                        alert("error getting data!");
                        console.log(error);
                    })
            },
            onSubmit() {
                if (this.Name & this.Age)
                    return true;
                this.errors = [];
                if (!this.Name)
                    this.errors.push("Name required");
                if (!this.Age)
                    this.errors.push("Age required");
                if (this.Age > 100)
                    this.errors.push("age is invalid");

                console.log("clicked");
                let all = { Name: this.Name, Age: this.Age };
                console.log(all)
                // this.$emit("all-a", all);
                //if (this.Name & this.Age) {

                    axios.post('http://localhost:50598/api/details/AddDetails', all)
                        .then((response) => {
                            console.log("inserted", response)
                            alert("inserted");
                            this.getDetails();

                        })
                        .catch(function (error) {
                            alert(error);
                        });
               // }


                
                //axios.post('/AddDetails',  all )
                //    .then((response) => {
                //        console.log("inserted", response)
                //        alert("inserted")
                //    })
                //    .catch((e) => { console.log("Error inserting", e)})
            },
            DeleteDetail(det) {
                console.log("Delete clicked", det);
                axios.post('http://localhost:50598/api/details/DeleteDetails', det)
                    .then((response) => {
                        console.log("Deleted", response)
                        alert("deleted");
                        this.getDetails();

                    })
                    .catch(function (err) {
                        alert(err);
                    })
                
            },
            EditDetails() {
               
               let edited = { Name: this.Name, Age: this.Age };

                axios.post('http://localhost:50598/api/details/EditDetails', edited).
                    then((respose) => {
                        console.log("edited", respose)
                        alert("Edited")
                        this.getDetails();

                    }).
                    catch(function (err) {
                        alert(err);
                    })
            },
            SeeDetails(p) {
                this.isEdit= true,
                this.Name = p.name,
                    this.Age = p.age
            }
        }
    }
</script>
<style>
    @import '../Styles/StyleSheet1.scss';
    @import'../Styles/StyleSheet2.scss';
</style>