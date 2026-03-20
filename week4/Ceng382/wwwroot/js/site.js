function previewGalleryImages(input) {
    var grid = document.getElementById('jsPreviewGrid');
    var placeholder = document.getElementById('previewPlaceholder');

    grid.innerHTML = '';

    if (!input.files || input.files.length === 0) {
        grid.style.display = 'none';
        placeholder.style.display = 'flex';
        return;
    }

    grid.style.display = 'grid';
    placeholder.style.display = 'none';

    Array.from(input.files).forEach(function (file) {
        var reader = new FileReader();
        reader.onload = function (e) {
            var div = document.createElement('div');
            div.className = 'gimg';
            var img = document.createElement('img');
            img.src = e.target.result;
            img.alt = file.name;
            div.appendChild(img);
            grid.appendChild(div);
        };
        reader.readAsDataURL(file);
    });
}
