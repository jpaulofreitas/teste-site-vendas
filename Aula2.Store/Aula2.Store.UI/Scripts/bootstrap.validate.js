$.validator.setDefaults({

    highlight: function (element) {

        $(element)
            .closest('.form-group')
            .find('input,label,select,textarea,span')
            .addClass('is-invalid')
    },

    unhighlight: function (element) { 

         $(element)
            .closest('.form-group')
            .find('input,label,select,textarea,span')
            .removeClass('is-invalid')
    },
})

//quando a validãção detectar um campo nao valido, executa a função, ele passa pra variavel elemento o input que nao foi validade
//unhighligh é qual nao foi validado
//localizar a classe mais proximo do metodo helper disparado 
//ele ira executar as funções acima : closest procura a class que eu quero, find para buscar, e add para executar