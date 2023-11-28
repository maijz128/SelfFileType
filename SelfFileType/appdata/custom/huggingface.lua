function Description()
    return
        'Hugging Face';
end

function ExtensionName() return '.huggingface'; end

function Icon() return 'huggingface.ico'; end

function Urls() return {'huggingface.co'}; end

function FileName(url)
    local name = "Hugging Face";
    name = url:gsub("https://huggingface.co/", "");
    name = name:gsub("/", ".");
    return name;
end


-- local url_model = 'https://huggingface.co/andite/pastel-mix';
-- print(FileName(url_model))


