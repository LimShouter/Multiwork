function UploadForm(){
    
    let fail =document.getElementById('fail-root');
    let loading =document.getElementById('loading');
    let formroot =document.getElementById('form-root');
    let success =document.getElementById('success');


    let form = {
        loadingRoot: document.getElementById('loading'),
        firstName: document.getElementById('first-name'),
        lastName: document.getElementById('last-name'),
        birthdate: document.getElementById('birthdate'),
        city: document.getElementById('city'),
        tel: document.getElementById('tel'),
        email: document.getElementById('email'),
    };

    form.loadingRoot.style.display = 'block';
    let request = new XMLHttpRequest();
    request.open("POST",'/FormLoad/',true)
    request.onload = () =>{
        var responseData = JSON.parse(request.responseText);
        console.log(responseData)
        if (responseData.status){
            fail.style.display = 'none';
            loading.style.display = 'none';
            formroot.style.display = 'none';
            success.style.display = 'block';
        }else{
            loading.style.display = 'none';
            fail.style.display = 'block';
            fail.textContent = responseData.failureTags;
        }
    };
    
    let formData = new FormData();
    formData.append('form.FirstName',form.firstName.value)
    formData.append('form.LastName',form.lastName.value)
    formData.append('form.Birthdate',form.birthdate.value)
    formData.append('form.City',form.city.value)
    formData.append('form.Tel',form.tel.value)
    formData.append('form.Email',form.email.value)
    
    request.send(formData)
}
