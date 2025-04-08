// Items page JavaScript

document.addEventListener("DOMContentLoaded", () => {
  // Set minimum auction end date to tomorrow
  const tomorrow = new Date()
  tomorrow.setDate(tomorrow.getDate() + 1)
  tomorrow.setHours(tomorrow.getHours())
  tomorrow.setMinutes(Math.ceil(tomorrow.getMinutes() / 5) * 5) // Round to next 5 minutes

  const minDateTime = tomorrow.toISOString().slice(0, 16)
  document.getElementById("auctionEndDate").min = minDateTime

  // Default end date to a week from now
  const oneWeekLater = new Date()
  oneWeekLater.setDate(oneWeekLater.getDate() + 7)
  oneWeekLater.setHours(oneWeekLater.getHours())
  oneWeekLater.setMinutes(Math.ceil(oneWeekLater.getMinutes() / 5) * 5)

  document.getElementById("auctionEndDate").value = oneWeekLater.toISOString().slice(0, 16)
  document.getElementById("previewEndDate").textContent = oneWeekLater.toLocaleDateString()

  // Define subcategories for each category
  const subcategories = {
    books: [
      "Fiction",
      "Non-fiction",
      "Religion",
      "Business",
      "Academic",
      "Children's Books",
      "Comics & Graphic Novels",
      "Rare & Collectible",
    ],
    furniture: [
      "Sofas & Seating",
      "Tables",
      "Bedroom",
      "Storage",
      "Decor",
      "Office Furniture",
      "Outdoor Furniture",
      "Antique Furniture",
    ],
    electronics: ["Smartphones", "Laptops", "Tablets", "Cameras", "Audio", "Gaming", "TVs", "Computer Parts"],
    clothing: ["Men's", "Women's", "Children's", "Vintage", "Shoes", "Accessories", "Formal Wear", "Sportswear"],
    collectibles: ["Coins", "Stamps", "Cards", "Comics", "Toys", "Memorabilia", "Vinyl Records", "Antiques"],
    jewelry: [
      "Rings",
      "Necklaces",
      "Earrings",
      "Bracelets",
      "Watches",
      "Vintage Jewelry",
      "Fine Jewelry",
      "Costume Jewelry",
    ],
    art: [
      "Paintings",
      "Sculptures",
      "Prints",
      "Photography",
      "Digital Art",
      "Mixed Media",
      "Pottery & Glass",
      "Folk Art",
    ],
    other: [
      "Sports Equipment",
      "Musical Instruments",
      "Home Appliances",
      "Garden & Outdoor",
      "Tools",
      "Crafts",
      "Pet Supplies",
      "Miscellaneous",
    ],
  }

  // Handle category change to update subcategories
  const itemCategory = document.getElementById("itemCategory")
  const subcategoryContainer = document.getElementById("subcategoryContainer")

  itemCategory.addEventListener("change", function () {
    const category = this.value
    updateSubcategories(category)

    // Update preview
    document.getElementById("previewCategory").textContent = category.charAt(0).toUpperCase() + category.slice(1)
  })

  function updateSubcategories(category) {
    subcategoryContainer.innerHTML = ""

    if (category && subcategories[category]) {
      const label = document.createElement("label")
      label.className = "form-label"
      label.htmlFor = "itemSubcategory"
      label.textContent = "Subcategory"

      const select = document.createElement("select")
      select.className = "form-select"
      select.id = "itemSubcategory"
      select.required = true

      // Add default option
      const defaultOption = document.createElement("option")
      defaultOption.value = ""
      defaultOption.textContent = "Select subcategory"
      select.appendChild(defaultOption)

      // Add subcategory options
      subcategories[category].forEach((sub) => {
        const option = document.createElement("option")
        option.value = sub.toLowerCase().replace(/\s+/g, "-")
        option.textContent = sub
        select.appendChild(option)
      })

      // Add invalid feedback
      const feedback = document.createElement("div")
      feedback.className = "invalid-feedback"
      feedback.textContent = "Please select a subcategory."

      subcategoryContainer.appendChild(label)
      subcategoryContainer.appendChild(select)
      subcategoryContainer.appendChild(feedback)

      // Add event listener for preview
      select.addEventListener("change", function () {
        const subcategory = this.options[this.selectedIndex].text
        if (subcategory !== "Select subcategory") {
          document.getElementById("previewCategory").textContent =
            `${itemCategory.value.charAt(0).toUpperCase() + itemCategory.value.slice(1)} / ${subcategory}`
        }
      })
    }
  }

  // Image preview
  const itemImage = document.getElementById("itemImage")
  const itemImagePreview = document.getElementById("itemImagePreview")

  itemImage.addEventListener("change", function () {
    const file = this.files[0]
    if (file) {
      const reader = new FileReader()
      reader.onload = (e) => {
        itemImagePreview.src = e.target.result

        // Add animation
        itemImagePreview.style.transition = "transform 0.5s ease"
        itemImagePreview.style.transform = "scale(1.05)"
        setTimeout(() => {
          itemImagePreview.style.transform = "scale(1)"
        }, 500)
      }
      reader.readAsDataURL(file)
    }
  })

  // Handle real-time preview updates
  const itemTitle = document.getElementById("itemTitle")
  const itemDescription = document.getElementById("itemDescription")
  const startingPrice = document.getElementById("startingPrice")
  const bidIncrement = document.getElementById("bidIncrement")
  const auctionEndDate = document.getElementById("auctionEndDate")

  itemTitle.addEventListener("input", function () {
    document.getElementById("previewTitle").textContent = this.value || "Item Title"
  })

  itemDescription.addEventListener("input", function () {
    document.getElementById("previewDescription").textContent =
      this.value.length > 150
        ? this.value.substring(0, 150) + "..."
        : this.value || "Item description will appear here."
  })

  startingPrice.addEventListener("input", function () {
    document.getElementById("previewPrice").textContent = `$${Number.parseFloat(this.value || 0).toFixed(2)}`
  })

  bidIncrement.addEventListener("input", function () {
    document.getElementById("previewIncrement").textContent = `$${Number.parseFloat(this.value || 0).toFixed(2)}`
  })

  auctionEndDate.addEventListener("change", function () {
    document.getElementById("previewEndDate").textContent = this.value
      ? new Date(this.value).toLocaleDateString()
      : "N/A"
  })

  // Form submission
  const sellItemForm = document.getElementById("sellItemForm")

  sellItemForm.addEventListener("submit", function (e) {
    e.preventDefault()

    if (!this.checkValidity()) {
      e.stopPropagation()
      this.classList.add("was-validated")
      return
    }

    // Generate a random auction ID for demo purposes
    const auctionId = Math.floor(100000 + Math.random() * 900000)
    document.getElementById("auctionId").textContent = auctionId

    // Show success modal
    const successModal = new bootstrap.Modal(document.getElementById("successModal"))
    successModal.show()
  })

  // View listing button click
  document.getElementById("viewListingBtn").addEventListener("click", () => {
    // This would typically redirect to a user's listings page
    // For demo purposes, we'll just close the modal
    const successModalElement = document.getElementById("successModal")
    const modal = bootstrap.Modal.getInstance(successModalElement)

    if (modal) {
      modal.hide()
    }

    // Reset form
    resetForm()
  })

  // Reset form function
  window.resetForm = () => {
    sellItemForm.reset()
    sellItemForm.classList.remove("was-validated")

    // Reset preview
    itemImagePreview.src = "https://via.placeholder.com/300x200?text=Item+Image"
    document.getElementById("previewTitle").textContent = "Item Title"
    document.getElementById("previewCategory").textContent = "Category"
    document.getElementById("previewPrice").textContent = "$0.00"
    document.getElementById("previewDescription").textContent = "Item description will appear here."
    document.getElementById("previewEndDate").textContent = oneWeekLater.toLocaleDateString()
    document.getElementById("previewIncrement").textContent = "$1.00"

    // Clear subcategories
    subcategoryContainer.innerHTML = ""

    // Reset auction end date to one week later
    document.getElementById("auctionEndDate").value = oneWeekLater.toISOString().slice(0, 16)
  }

  const resetForm = window.resetForm
  const bootstrap = window.bootstrap
})
