<template>
    <form @submit="handlesubmit">
        <h3>Login</h3>
        <div class="form-group">
            <label>Email</label>
            <input type="email" class="form-control" v-model="email" placeholder="Email" />
        </div>
        <div class="form-group">
            <label>Password</label>
            <input type="password" class="form-control" v-model="password" placeholder="Password" />
        </div>

        <button class="btn btn-primary">Login</button>

        <!--  <datepicker placeholder="European Format ('d-m-Y')" :config="{ dateFormat: 'd-m-Y', static: true }"></datepicker>-->
        <!--<progress-bar :variant="'info'"
                      :size="'normal'"
                      :value="progressValue"
                      :max="100"
                      :label="true">
        </progress-bar>-->

    </form>
</template>

<script>
    import axios from 'axios';
    //import VueRouter from 'vue-router';
   // import router from '../router';
    // Datepicker from 'vue-bulma-datepicker'
    //import ProgressBar from "vue-bulma-progress-component"


    export default {
        name: 'Login',
        components: {
          //  Datepicker
          //  ProgressBar 
        },
        data() {
            return {
                email: '',
                password: '',
                //progressValue: 45
            }
        },
        methods: {
            async handlesubmit(e) {
                e.preventDefault()
                console.log("submitted");
                //const data = {
                //    email: this.email,
                //    password: this.password
                //}
                //console.log(data);

                await axios.post('http://localhost:50598/api/details/Login', {
                    email: this.email,
                    password: this.password
                })
                    .then(res => {
                        console.log(res);
                        localStorage.setItem('user', JSON.stringify('abhi'));
                        var us = localStorage.getItem('user');
                        console.log("uss", us)  
                        this.$router.push('/FetchData');
                      

                }).catch(err=>{
                    console.log("not logged in ",err)
                })
            }
        }
    }
</script>