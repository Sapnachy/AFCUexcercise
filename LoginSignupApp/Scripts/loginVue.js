var loginscript = new Vue({
    el: '#logindiv',
    data: {
        email: '',
        password: '',
        errorMessage: ''
    },
    methods: {
        onSubmit: function () {
            if (this.email == '' || this.password == '') {
                this.errorMessage = "Email and Password are required!";
            }
            else {
                axios.post('Login/Login', {
                    email: this.email,
                    password: this.password
                })
                    .then(response => {
                        //redirect here to a new page
                    })
                    .catch(e => {
                        this.errorMessage = e;
                    })
            }
        }
    }

})