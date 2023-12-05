var ctx = document.getElementById('myChart').getContext('2d');
var myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ['Approved', 'Rejected'],
        datasets: [{
            label: 'Website Visits',
            data: [4, 5], // Update this array to have the desired number of visits for the 'Approved' and 'Rejected' statuses
            backgroundColor: [
                'rgba(75, 192, 192, 0.2)', // Update this array to have the desired colors for the bars
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(75, 192, 192, 1)', // Update this array to have the desired border colors for the bars
                'rgba(255, 99, 132, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});

function updateChart(approved, rejected) {
    myChart.data.datasets[0].data[0] = approved;
    myChart.data.datasets[0].data[1] = rejected;
    myChart.update();
}

// Example: Update the chart with new data
updateChart(6, 7);