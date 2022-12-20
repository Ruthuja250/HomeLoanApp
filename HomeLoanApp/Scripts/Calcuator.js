let loanAmount;

function calculateLoan() {
    let monthlyIncome = document.querySelector("#loanInp").value
    console.log("Monthly Income is= ", monthlyIncome)
    let loanAmount = 60 * (0.6 * monthlyIncome)
    console.log("Eligible Loan Amount= ", loanAmount)
    let str = ""
    str +=
        ` 
<div class="pad">
You are Eligible for a loan of ${loanAmount}₹. 
</div>
`
    document.querySelector("#loanOutput").innerHTML = str
}

var loanForm = document.getElementById("loanForm");
function handleForm(event) { event.preventDefault(); }
loanForm.addEventListener('submit', handleForm);

function calculateEMI() {
    let months;
    loanAmount = document.querySelector("#emiLoan").value
    months = document.querySelector("#emiTenure").value
    console.log("loan amount is ", loanAmount, " and time period is ", months, " months")
    let rateOfInterest = (8.5 / 12) / 100
    console.log("rate of intrest is ", rateOfInterest)
    let emi = (loanAmount * rateOfInterest * ((Math.pow((1 + rateOfInterest), months)) / (Math.pow((1 + rateOfInterest), months) - 1))).toFixed(2)
    let str = ""
    str +=
        `<div class="pad">
Your EMI is ${emi}₹ 
</div>`
    document.querySelector("#emiOutput").innerHTML = str
}

var emiForm = document.getElementById("emiForm");
function handleEmiForm(event) { event.preventDefault(); }
emiForm.addEventListener('submit', handleEmiForm);

